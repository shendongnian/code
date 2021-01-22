    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.PointOfService;
    using System.Collections;
    
    namespace MicrosoftPOSScannerSample
    {
        public partial class Form1 : Form
        {
            private PosExplorer explorer;
    		private Scanner scanner;
    
            public Form1()
            {
                InitializeComponent();
                explorer = new PosExplorer(this);
                explorer.DeviceAddedEvent += new DeviceChangedEventHandler(explorer_DeviceAddedEvent);
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    		}
    		
    		private void UpdateEventHistory(string newEvent)
            {
                txtbEventHistory.Text = newEvent + System.Environment.NewLine + txtbEventHistory.Text;
            }
    
            void explorer_DeviceAddedEvent(object sender, DeviceChangedEventArgs e)
            {
                if (e.Device.Type == "Scanner")
                {
                    scanner = (Scanner)explorer.CreateInstance(e.Device);
                    scanner.Open();
                    scanner.Claim(1000);
                    scanner.DeviceEnabled = true;
                    scanner.DataEvent += new DataEventHandler(scanner_DataEvent);
                    scanner.DataEventEnabled = true;
                    scanner.DecodeData = true;
                }
            }
    		
    		void scanner_DataEvent(object sender, DataEventArgs e)
            {
                UpdateEventHistory("Data Event");
                ASCIIEncoding encoder = new ASCIIEncoding();
                try
                {
                    // Display the ASCII encoded label text
                    txtbScanDataLabel.Text = encoder.GetString(scanner.ScanDataLabel);
                    // Display the encoding type
                    txtbScanDataType.Text = scanner.ScanDataType.ToString();
    
                    // re-enable the data event for subsequent scans
                    scanner.DataEventEnabled = true;
                }
                catch (PosControlException)
                {
                    // Log any errors
                    UpdateEventHistory("DataEvent Operation Failed");
                }
            }
    		
    	}
    }
		
		
