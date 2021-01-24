    using System;
    using System.IO.Ports;
    using System.Windows;
    using System.Windows.Input;
    namespace SerialTest
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SerialPort port = new SerialPort();
        int intBaud = 0;
        string strComport = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cbCom.ItemsSource = ports;
        }
        private void StartUp()
        {
            int intbaud;
            if (int.TryParse(cbBaud.SelectionBoxItem.ToString(), out intbaud))
            {
                intBaud = intbaud;
               strComport = cbCom.SelectedItem.ToString();
                SerialStart();
            }
            else
            {
                MessageBox.Show("Enter a valid Baudrate");
            }
        }
        private void SerialStart()
        {
            try
            {
                port.BaudRate = int.Parse(cbBaud.SelectionBoxItem.ToString());
                port.DataBits = 8;
                port.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                port.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                port.PortName = cbCom.SelectedItem.ToString();
                port.DataReceived += new SerialDataReceivedEventHandler(SerialReceive);
                port.Handshake = Handshake.None;
                if (port.IsOpen) port.Close();
                port.Open();
            }
            catch (Exception ex)
            {
                txtTerm.AppendText(ex.ToString());
            }
        }
        public enum LogMsgType { Incoming, Outgoing, Normal, Warning, Error };
        private void Log(LogMsgType msgtype, string msg)
        {
            try
            {
                txtTerm.Dispatcher.Invoke(new EventHandler(delegate
                {
                    txtTerm.AppendText(msg);
                }));
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void SerialReceive(object sender, SerialDataReceivedEventArgs e)
        {
            if (!port.IsOpen) return;
            string data = port.ReadExisting();
            this.Dispatcher.Invoke(() =>
            {
                txtTerm.AppendText(data);
                txtTerm.ScrollToEnd();
            });
        }
        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && port.IsOpen)
            {
                try
                {
                    port.WriteLine(txtInput.Text + "\r\n");
                }
                catch (Exception ex)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        txtTerm.AppendText(ex.ToString()); ;
                    });
                }
                this.Dispatcher.Invoke(() =>
                {
                    txtTerm.AppendText(txtInput.Text + "\n");
                    txtInput.Text = "";
                });
            }
        }
    }
    }
