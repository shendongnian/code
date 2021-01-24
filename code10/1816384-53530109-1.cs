        private void PopQueue(object sender, EventArgs e)
        {
            lock(bufferStrings)
            {
                foreach (var queueString in bufferStrings)
                {
                    AppendText(queueString);
                }
                bufferStrings.Clear();
            }
        }
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (_serialPort != null)
            {
                lock(bufferStrings)
                {
                    bufferStrings.Add(((SerialPort)sender).ReadLine());
                    //AppendText(((SerialPort) sender).ReadLine());
                }
            }
        }
