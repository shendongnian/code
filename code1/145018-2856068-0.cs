       private void MonitorSP_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                try
                {
                    System.IO.Ports.SerialPort SP = (System.IO.Ports.SerialPort)sender;
    
                    //Get the ports available in system
                    string[] theSerialPortNames = System.IO.Ports.SerialPort.GetPortNames();
                    string strAvlPortNames = "";
                    foreach (string s in theSerialPortNames)
                    {
                        strAvlPortNames += s.ToString() + ", ";
                    }
    
                    //Read an contruct the message
                    Thread.Sleep(1000);
                    string msg = SP.ReadExisting();
                    string ConstructedMsg = "Port's Found : " + strAvlPortNames + "\n" + "Port Used : " + SP.PortName + "\n" + "Message Received : " + msg;
    
                    if (InvokeRequired)
                    {
                        richTextBox1.Invoke(new MethodInvoker(delegate { richTextBox1.Text = ConstructedMsg; }));
                        //Send acknowlegement to sender port
                        SP.Write(SP.PortName);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace.ToString());
                }
            }  
