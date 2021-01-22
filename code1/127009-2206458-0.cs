    using System;
    using System.Net.NetworkInformation;
    using System.Windows.Forms;
    
    namespace InterfaceTrafficWatch
    {
        /// <summary>
        /// Network Interface Traffic Watch
        /// by Mohamed Mansour
        /// 
        /// Free to use under GPL open source license!
        /// </summary>
        public partial class MainForm : Form
        {
            /// <summary>
            /// Timer Update (every 1 sec)
            /// </summary>
            private const double timerUpdate = 1000;
    
            /// <summary>
            /// Interface Storage
            /// </summary>
            private NetworkInterface[] nicArr;
    
            /// <summary>
            /// Main Timer Object 
            /// (we could use something more efficient such 
            /// as interop calls to HighPerformanceTimers)
            /// </summary>
            private Timer timer;
    
            /// <summary>
            /// Constructor
            /// </summary>
            public MainForm()
            {
                InitializeComponent();
                InitializeNetworkInterface();
                InitializeTimer();
            }
    
            /// <summary>
            /// Initialize all network interfaces on this computer
            /// </summary>
            private void InitializeNetworkInterface()
            {
                // Grab all local interfaces to this computer
                nicArr = NetworkInterface.GetAllNetworkInterfaces();
    
                // Add each interface name to the combo box
                for (int i = 0; i < nicArr.Length; i++)
                    cmbInterface.Items.Add(nicArr[i].Name);
    
                // Change the initial selection to the first interface
                cmbInterface.SelectedIndex = 0;
            }
    
            /// <summary>
            /// Initialize the Timer
            /// </summary>
            private void InitializeTimer()
            {
                timer = new Timer();
                timer.Interval = (int)timerUpdate;
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }
    
            /// <summary>
            /// Update GUI components for the network interfaces
            /// </summary>
            private void UpdateNetworkInterface()
            {
                // Grab NetworkInterface object that describes the current interface
                NetworkInterface nic = nicArr[cmbInterface.SelectedIndex];
    
                // Grab the stats for that interface
                IPv4InterfaceStatistics interfaceStats = nic.GetIPv4Statistics();
    
                // Calculate the speed of bytes going in and out
                // NOTE: we could use something faster and more reliable than Windows Forms Tiemr
                //       such as HighPerformanceTimer http://www.m0interactive.com/archives/2006/12/21/high_resolution_timer_in_net_2_0.html
                int bytesSentSpeed = (int)(interfaceStats.BytesSent - double.Parse(lblBytesSent.Text)) / 1024;
                int bytesReceivedSpeed = (int)(interfaceStats.BytesReceived - double.Parse(lblBytesReceived.Text)) / 1024;
    
                // Update the labels
                lblSpeed.Text = nic.Speed.ToString();
                lblInterfaceType.Text = nic.NetworkInterfaceType.ToString();
                lblSpeed.Text = nic.Speed.ToString();
                lblBytesReceived.Text = interfaceStats.BytesReceived.ToString();
                lblBytesSent.Text = interfaceStats.BytesSent.ToString();
                lblUpload.Text = bytesSentSpeed.ToString() + " KB/s";
                lblDownload.Text = bytesReceivedSpeed.ToString() + " KB/s";
    
            }
    
            /// <summary>
            /// The Timer event for each Tick (second) to update the UI
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void timer_Tick(object sender, EventArgs e)
            {
                UpdateNetworkInterface();
            }
    
        }
    }
