            int dwFlagsAndAttributes = 0x40000000;
            
            var portName = "COM5";
            var isValid = SerialPort.GetPortNames().Any(x => string.Compare(x, portName, true) == 0);
            if (!isValid)
                throw new System.IO.IOException(string.Format("{0} port was not found", portName));
            //Borrowed from Microsoft's Serial Port Open Method :)
            SafeFileHandle hFile = CreateFile(@"\\.\" + portName, -1073741824, 0, IntPtr.Zero, 3, dwFlagsAndAttributes, IntPtr.Zero);
            if (hFile.IsInvalid)
                throw new System.IO.IOException(string.Format("{0} port is already open", portName));
            hFile.Close();
            using (var serialPort = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One))
            {
                serialPort.Open();
            }
