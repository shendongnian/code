        public void mySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort) sender;
            var dataRcvd = sp.ReadExisting();
            object[] dataArray = new object[1];
            dataArray[0] = dataRcvd;
            BeginInvoke( new postDataDelegate( postData), dataArray );
        }
        private delegate void postDataDelegate( string d );
        private void postData( string d) 
        {
            textBox4.Text = d;
        }
