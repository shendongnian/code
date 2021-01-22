    private string portName { get; set; } = string.Empty;
    
        /// <summary>
        /// Returns SerialPort Port State (Open / Closed)
        /// </summary>
        /// <returns></returns>
        internal bool HasOpenPort()
        {
            bool portState = false;
    
            if (portName != string.Empty)
            {
                using (SerialPort serialPort = new SerialPort(portName))
                {
                    foreach (var itm in SerialPort.GetPortNames())
                    {
                        if (itm.Contains(serialPort.PortName))
                        {
                            if (serialPort.IsOpen) { portState = true; }
                            else { portState = false; }
                        }
                    }
                }
            }
    
            else { System.Windows.Forms.MessageBox.Show("Error: No Port Specified."); }
    
            return portState;
    }
