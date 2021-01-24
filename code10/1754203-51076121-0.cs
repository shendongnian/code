        private async read_gps_data(string port = "UART0", int baud = 9600)
        {
                string aqs = SerialDevice.GetDeviceSelector("UART0");                   /* Find the selector string for the serial device   */
                var dis = await DeviceInformation.FindAllAsync(aqs);                    /* Find the serial device with our selector string  */
                SerialDevice SerialPort = await SerialDevice.FromIdAsync(dis[0].Id);    /* Create an serial device with our selected device */
                /* Configure serial settings */
                SerialPort.WriteTimeout = TimeSpan.FromMilliseconds(1000);
                SerialPort.ReadTimeout = TimeSpan.FromMilliseconds(1000);
                SerialPort.BaudRate = 9600;                                             /* mini UART: only standard baudrates */
                SerialPort.Parity = SerialParity.None;                                  /* mini UART: no parities */
                SerialPort.StopBits = SerialStopBitCount.One;                           /* mini UART: 1 stop bit */
                SerialPort.DataBits = 8;
                /* Read data in from the serial port */
                const uint maxReadLength = 1024;
                DataReader dataReader = new DataReader(SerialPort.InputStream);
                string rxBuffer = "";
                while (true)
                {
                	await Task.Run(async () =>
               		{
            			try
            			{
                            		uint bytesToRead = await dataReader.LoadAsync(maxReadLength);
                            		rxBuffer = dataReader.ReadString(bytesToRead);
                            		Debug.WriteLine(rxBuffer);
                            		Debug.WriteLine("\n");
            			}
            			catch (Exception ex)
            			{
                			Debug.WriteLine(ex);
            			}
                        	await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                       		{
                                        // Update UI here
                            		receivedData.text = rxBuffer;
                        	});
                	});
                }
        }
