    internal class Client
    {
		private FileStream _fs;		
        private long _expectedLength;
        
        public void GetFileFromServer(string localFilename)
        {            
            if (File.Exists(localFilename))
                File.Delete(localFilename);
            
            _fs = new FileStream(localFilename, FileMode.Append);
            var ipEndpointServer = new IPEndPoint(IPAddress.Parse({serverIp}), {serverPort});
			
			// an object that wraps tcp client
            var client = new TcpClientWrapper(ipEndpointServer, "");
            client.DataReceived += DataReceived;
        }
        private void DataReceived(object sender, DataReceivedEventArgs e)
        {
            var data = e.Data;
			// first packet starts with 4 bytes dedicated to the length of the file
            if (_expectedLength == 0)
            {
                var headerBytes = new byte[4];
                Array.Copy(e.Data, 0, headerBytes, 0, 4);
                _expectedLength = BitConverter.ToInt32(headerBytes, 0);
                data = new byte[e.Data.Length - 4];
                Array.Copy(e.Data, 4, data, 0, data.Length);
            }
            _fs.WriteAsync(e.Data, 0, e.Data.Length);
                       
            if (_fs.Length >= _expectedLength)
            {                                
                // transfer has finished
            }
        }
    }
