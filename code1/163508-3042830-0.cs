    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using System.Configuration;
    
    using UsbEject.Library;
    using Utils;
    
    namespace Hardware
    {
        public class TeliaModem : IDisposable
        {
            public delegate void NewSmsHandler(InboundSMS sms);
            public event NewSmsHandler OnNewSMS;
    
            #region private data
            System.IO.Ports.SerialPort modemPort;
    
            Timeouter _lastModemKeepAlive;
    
            private delegate void DataReceivedDelegate();
            private DataReceivedDelegate dataReceivedDelegate;
    
            Queue<OutboundSMS> _outSmses = new Queue<OutboundSMS>();
    
            enum ModemState
            {
                Error = -1, NotInitialized, PowerUp, Initializing, Idle,
                SendingSMS, KeepAliveAwaitingResponse
            };
    
            Timeouter ModemStateTimeouter = new Timeouter(timeout_s: 10, autoReset: false);
            ModemState _modemState = ModemState.NotInitialized;
            ModemState CurrentModemState
            {
                get
                {
                    return _modemState;
                }
                set
                {
                    _modemState = value;
                    ModemStateTimeouter.Reset();
                    NihLog.Write(NihLog.Level.Debug, "State changed to: " + value.ToString());
                }
            }
    
            private System.Windows.Forms.Control _mainThreadOwnder;
            #endregion
    
            public TeliaModem(System.Windows.Forms.Control mainThreadOwnder)
            {
                _mainThreadOwnder = mainThreadOwnder;
    
                dataReceivedDelegate = new DataReceivedDelegate(OnDataReceived);
            }
            
            public void SendSMS(string phone, string text)
            {
                _outSmses.Enqueue(new OutboundSMS(phone, text));
                HeartBeat();
            }
    
            private void SendSmsNow()
            {
                OutboundSMS sms = _outSmses.Peek();
                sms.Attempt++;
                if (sms.Attempt > sms.MaxTries)
                {
                    NihLog.Write(NihLog.Level.Error, "Failure to send after " + sms.MaxTries + " tries");
                    _outSmses.Dequeue();
                    return;
                }
    
                NihLog.Write(NihLog.Level.Info, "Sending SMS: " + sms.ToString());
                WriteToModem("AT+CMGS=\"" + sms.Destination + "\"\r");
                System.Threading.Thread.Sleep(500);
                WriteToModem(sms.Text);
    
                byte[] buffer = new byte[1];
                buffer[0] = 26; // ^Z
                modemPort.Write(buffer, offset:0, count:1);
    
                CurrentModemState = ModemState.SendingSMS;
            }
    
            public void Dispose()
            {
                UninitModem();
            }
    
            public void HeartBeat()
            {
                if (CurrentModemState == ModemState.NotInitialized)
                {
                    TryInitModem();
                    return;
                }
    
                if (IsTransitionalState(CurrentModemState) && ModemStateTimeouter.IsTimedOut())
                {
                    NihLog.Write(NihLog.Level.Error, "Modem error. Timed out during " + CurrentModemState);
                    CurrentModemState = ModemState.Error;
                    return;
                }
    
                if (CurrentModemState == ModemState.Idle && _lastModemKeepAlive.IsTimedOut())
                {
                    // Send keepalive
                    WriteToModem("AT\r");
                    CurrentModemState = ModemState.KeepAliveAwaitingResponse;
                    return;
                }
    
                if (CurrentModemState == ModemState.Error)
                {
                    NihLog.Write(NihLog.Level.Debug, "Reenumerating modem...");
                    UninitModem();
                    return;
                }
    
                if (_outSmses.Count != 0 && CurrentModemState == ModemState.Idle)
                {
                    SendSmsNow();
                    return;
                }
            }
            
            private string pendingData;
            private void OnDataReceived()
            {
                // Called in the main thread
    
                string nowWhat = modemPort.ReadExisting();
                pendingData += nowWhat;
                string[] lines = pendingData.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                if (lines.Length == 0)
                {
                    pendingData = string.Empty;
                    return;
                }
                else
                {
                    pendingData = lines[lines.Length - 1];
                }
    
                // This happens in main thread.
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    string line = lines[i];
    
                    if (line.Length >= 5 && line.Substring(0, 5) == "+CMT:")
                    {
                        // s+= read one more line
                        if (i == lines.Length - 1) // no next line
                        {
                            pendingData = line + "\r\n" + pendingData; // unread the line
                            continue;
                        }
                        string line2 = lines[++i];
                        NihLog.Write(NihLog.Level.Debug, "RX " + line);
                        NihLog.Write(NihLog.Level.Debug, "RX " + line2);
                        InboundSMS sms = new InboundSMS();
                        sms.ParseCMT(line, line2);
                        if(OnNewSMS != null)
                            OnNewSMS(sms);
                    }
                    else   // Not a composite
                        NihLog.Write(NihLog.Level.Debug, "RX " + line);
    
                    if (line == "OK")
                    {
                        OnModemResponse(true);
                    }
                    else if (line == "ERROR")
                    {
                        OnModemResponse(false);
                        NihLog.Write(NihLog.Level.Error, "Modem error");
                    }
                }
            }
    
            private void ProcessSmsResult(bool ok)
            {
                if (!ok)
                {
                    OutboundSMS sms = _outSmses.Peek();
                    if (sms.Attempt < sms.MaxTries)
                    {
                        NihLog.Write(NihLog.Level.Info, "Retrying sms...");
                        return;
                    }
    
                    NihLog.Write(NihLog.Level.Error, "Failed to send SMS: " + sms.ToString());
                }
    
                _outSmses.Dequeue();
            }
    
            private void OnModemResponse(bool ok)
            {
                if (CurrentModemState == ModemState.SendingSMS)
                    ProcessSmsResult(ok);
    
                if (!ok)
                {
                    NihLog.Write(NihLog.Level.Error, "Error during state " + CurrentModemState.ToString());
                    CurrentModemState = ModemState.Error;
                    return;
                }
    
                switch (CurrentModemState)
                {
                    case ModemState.NotInitialized:
                        return;
    
                    case ModemState.PowerUp:
                        WriteToModem("ATE0;+CMGF=1;+CSCS=\"IRA\";+CNMI=1,2\r");
                        CurrentModemState = ModemState.Initializing;
                        break;
    
                    case ModemState.Initializing:
                    case ModemState.SendingSMS:
                    case ModemState.KeepAliveAwaitingResponse:
                        CurrentModemState = ModemState.Idle;
                        break;
                }
            }
    
            private void CloseU9TelitNativeApp()
            {
                bool doneSomething;
    
                do
                {
                    doneSomething = false;
    
                    Process[] processes = Process.GetProcessesByName("wirelesscard");
                    foreach (Process p in processes)
                    {
                        p.CloseMainWindow();
                        doneSomething = true;
                        NihLog.Write(NihLog.Level.Info, "Killed native U9 app");
                        System.Threading.Thread.Sleep(1000); // Will not wait if no native app is started
                    }
                } while (doneSomething);
            }
    
            void WriteToModem(string s)
            {
                modemPort.Write(s);
                NihLog.Write(NihLog.Level.Debug, "TX " + s);
            }
    
            void UninitModem()
            {
                if (modemPort != null)
                    modemPort.Dispose();
                modemPort = null;
                CurrentModemState = ModemState.NotInitialized;
            }
    
            private bool IsTransitionalState(ModemState ms)
            {
                return ms == ModemState.Initializing
                    || ms == ModemState.SendingSMS
                    || ms == ModemState.PowerUp
                    || ms == ModemState.KeepAliveAwaitingResponse;
            }
    
            Timeouter _initFailureTimeout = 
                new Timeouter(timeout_s: 10, autoReset:false, timedOut:true);
            
            void TryInitModem()
            {
                // Try pistoning the modem with higher frequency. This does no harm (such as redundant logging)
                PrepareU9Modem();   // Will do nothing if modem is okay
    
                if (!_initFailureTimeout.IsTimedOut())
                    return; // Don't try too frequently
    
                if (modemPort != null)
                    return;
    
                const string modemPortName = "Basecom HS-USB NMEA 9000";
                const int speed = 115200;
    
                string portName = Hardware.Misc.SerialPortFromFriendlyName(modemPortName);
                if (portName == null)
                {
                    NihLog.Write(NihLog.Level.Error, "Modem not found (yet). ");
                    _initFailureTimeout.Reset();
                    return;
                }
    
                NihLog.Write(NihLog.Level.Info, string.Format("Found modem port \"{0}\" at {1}", modemPortName, portName));
                modemPort = new System.IO.Ports.SerialPort(portName, speed);
                modemPort.ReadTimeout = 3000;
                modemPort.NewLine = "\r\n";
    
                modemPort.Open();
    
                modemPort.DiscardInBuffer();
                modemPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(delegate { _mainThreadOwnder.Invoke(dataReceivedDelegate); });  // called in different thread!
    
                _lastModemKeepAlive = new Timeouter(60, true);
    
                WriteToModem("AT+CFUN=1\r");
                CurrentModemState = ModemState.PowerUp;
            }
    
            void CheatU9Telit()
            {
                // U9 telit appears as USB CDrom on the bus, until disk eject is sent.
                // Then, it reappears as normal stuff.
    
                VolumeDeviceClass volumeDeviceClass = new VolumeDeviceClass();
                foreach (Volume device in volumeDeviceClass.Devices)
                {
                    if (device.FriendlyName == "PCL HSUPA Modem USB Device")
                    {
                        NihLog.Write(NihLog.Level.Info, "Trying to initialize: " + device.FriendlyName);
                        device.EjectCDRomNoUI();
                    }
                }
            }
    
            void PrepareU9Modem()
            {
                CloseU9TelitNativeApp(); // Closes the autorun native app
                CheatU9Telit();
            }
        }
    
        public class OutboundSMS
        {
            public string Destination;
            public string Text;
            public int MaxTries;
            public int Attempt = 0;
    
            public OutboundSMS(string dest, string txt)
            {
                Destination = dest;
                Text = txt;
                MaxTries = 3;
            }
    
            override public string ToString()
            {
                if(Attempt > 1)
                    return string.Format("\"{0}\" to {1}, attempt {2}", 
                        Text, Destination, Attempt);
                else
                    return string.Format("\"{0}\" to {1}",
                        Text, Destination);
            }
        }
    
        public class InboundSMS
        {
            public string SourcePhone;
            public DateTime ReceiveTime;
            public string Text;
    
            public void ParseCMT(string line1, string line2)
            {
                string[] fields = line1.Split(new char[] { ',', ' ', '/', ':', '"' });
                if (fields.Length < 12)
                    throw new ApplicationException("CMT message too short. Expected 2 fields");
    
                SourcePhone = fields[3];
                ReceiveTime = DateTime.Parse("20" + fields[7] + "-" + fields[8] + "-" + fields[9] + " " + fields[10] + ":" + fields[11] + ":" + fields[12].Substring(0, 2));   //test carefully
                Text = line2;
            }
        };
    }
