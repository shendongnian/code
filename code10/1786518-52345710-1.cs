    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
    using System.Management;
    using System.Management.Automation;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Data;
    namespace BluetoothInformation
    {
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            private ObservableCollection<COMPort> comPorts = new ObservableCollection<COMPort>();
            public ObservableCollection<COMPort> COMPorts {
                get => comPorts;
                set {
                    comPorts = value;
                    RaisePropertyChanged();
                }
            }
            private bool canRefresh = false;
            public bool CanRefresh {
                get => canRefresh;
                set {
                    canRefresh = value;
                    RaisePropertyChanged();
                }
            }
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
                GetBluetoothCOMPort();
            }
            private string ExtractBluetoothDevice(string pnpDeviceID)
            {
                int startPos = pnpDeviceID.LastIndexOf('_') + 1;
                return pnpDeviceID.Substring(startPos);
            }
            private string ExtractDevice(string pnpDeviceID)
            {
                int startPos = pnpDeviceID.LastIndexOf('&') + 1;
                int length = pnpDeviceID.LastIndexOf('_') - startPos;
                return pnpDeviceID.Substring(startPos, length);
            }
            private string ExtractCOMPortFromName(string name)
            {
                int openBracket = name.IndexOf('(');
                int closeBracket = name.IndexOf(')');
                return name.Substring(openBracket + 1, closeBracket - openBracket - 1);
            }
            private string ExtractHardwareID(string fullHardwareID)
            {
                int length = fullHardwareID.LastIndexOf('_');
                return fullHardwareID.Substring(0, length);
            }
            private bool TryFindPair(string pairsName, string hardwareID, List<ManagementObject> bluetoothCOMPorts, out COMPort comPort)
            {
                foreach (ManagementObject bluetoothCOMPort in bluetoothCOMPorts)
                {
                    string itemHardwareID = ((string[])bluetoothCOMPort["HardwareID"])[0];
                    if (hardwareID != itemHardwareID && ExtractHardwareID(hardwareID) == ExtractHardwareID(itemHardwareID))
                    {
                        comPort = new COMPort(ExtractCOMPortFromName(bluetoothCOMPort["Name"].ToString()), Direction.INCOMING, pairsName);
                        return true;
                    }
                }
                comPort = null;
                return false;
            }
            private string GetDataBusName(string pnpDeviceID)
            {
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    PowerShellInstance.AddScript($@"Get-PnpDeviceProperty -InstanceId '{pnpDeviceID}' -KeyName 'DEVPKEY_Device_BusReportedDeviceDesc' | select-object Data");
                    Collection<PSObject> PSOutput = PowerShellInstance.Invoke();
                    foreach (PSObject outputItem in PSOutput)
                    {
                        if (outputItem != null)
                        {
                            Console.WriteLine(outputItem.BaseObject.GetType().FullName);
                            foreach (var p in outputItem.Properties)
                            {
                                if (p.Name == "Data")
                                {
                                    return p.Value?.ToString();
                                }
                            }
                        }
                    }
                }
                return string.Empty;
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                GetBluetoothCOMPort();
            }
            private async void GetBluetoothCOMPort()
            {
                CanRefresh = false;
                COMPorts.Clear();
                await Task.Run(() => {
                    ManagementObjectCollection results = new ManagementObjectSearcher(@"SELECT PNPClass, PNPDeviceID, Name, HardwareID FROM Win32_PnPEntity WHERE (Name LIKE '%COM%' AND PNPDeviceID LIKE '%BTHENUM%' AND PNPClass = 'Ports') OR (PNPClass = 'Bluetooth' AND PNPDeviceID LIKE '%BTHENUM\\DEV%')").Get();
                    List<ManagementObject> bluetoothCOMPorts = new List<ManagementObject>();
                    List<ManagementObject> bluetoothDevices = new List<ManagementObject>();
                    foreach (ManagementObject queryObj in results)
                    {
                        if (queryObj["PNPClass"].ToString() == "Bluetooth")
                        {
                            bluetoothDevices.Add(queryObj);
                        }
                        else if (queryObj["PNPClass"].ToString() == "Ports")
                        {
                            bluetoothCOMPorts.Add(queryObj);
                        }
                    }
                    foreach (ManagementObject bluetoothDevice in bluetoothDevices)
                    {
                        foreach (ManagementObject bluetoothCOMPort in bluetoothCOMPorts)
                        {
                            string comPortPNPDeviceID = bluetoothCOMPort["PNPDeviceID"].ToString();
                            if (ExtractBluetoothDevice(bluetoothDevice["PNPDeviceID"].ToString()) == ExtractDevice(comPortPNPDeviceID))
                            {
                                COMPort outgoingPort = new COMPort(ExtractCOMPortFromName(bluetoothCOMPort["Name"].ToString()), Direction.OUTGOING, $"{bluetoothDevice["Name"].ToString()} \'{GetDataBusName(comPortPNPDeviceID)}\'");
                                Dispatcher.Invoke(() => {
                                    COMPorts.Add(outgoingPort);
                                });
                                if (TryFindPair(bluetoothDevice["Name"].ToString(), ((string[])bluetoothCOMPort["HardwareID"])[0], bluetoothCOMPorts, out COMPort incomingPort))
                                {
                                    Dispatcher.Invoke(() => {
                                        COMPorts.Add(incomingPort);
                                    });
                                }
                            }
                        }
                    }
                });
            
                CanRefresh = true;
            }
        }
        public class COMPort : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            private string comPortPort;
            public string COMPortPort {
                get => comPortPort;
                set {
                    comPortPort = value;
                    RaisePropertyChanged();
                }
            }
            private Direction comPortDirection;
            public Direction COMPortDirection {
                get => comPortDirection;
                set {
                    comPortDirection = value;
                    RaisePropertyChanged();
                }
            }
            private string comPortName;
            public string COMPortName {
                get => comPortName;
                set {
                    comPortName = value;
                    RaisePropertyChanged();
                }
            }
            public COMPort(string comPortPort, Direction comPortDirection, string comPortName)
            {
                COMPortPort = comPortPort;
                COMPortDirection = comPortDirection;
                COMPortName = comPortName;
            }
        }
        [ValueConversion(typeof(Direction), typeof(string))]
        public class DirectionConverter : IValueConverter
        {
            private const string UNDEFINED_DIRECTION = "UNDEFINED";
            private const string INCOMING_DIRECTION = "Incoming";
            private const string OUTGOING_DIRECTION = "Outgoing";
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                switch ((Direction)value)
                {
                    case Direction.UNDEFINED:
                        return UNDEFINED_DIRECTION;
                    case Direction.INCOMING:
                        return INCOMING_DIRECTION;
                    case Direction.OUTGOING:
                        return OUTGOING_DIRECTION;
                }
                return string.Empty;
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
        public enum Direction
        {
            UNDEFINED,
            INCOMING,
            OUTGOING
        }
    }
