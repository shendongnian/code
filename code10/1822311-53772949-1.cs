        private void GetMessage()
        {
            while (_clientSocket.Connected)
            {
                _serverStream = _clientSocket.GetStream();
                byte[] inStream = new byte[_clientSocket.ReceiveBufferSize];
                int buffSize = _clientSocket.ReceiveBufferSize;
                _serverStream.Read(inStream, 0, buffSize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                if (returndata.StartsWith("$CodeStart"))
                {
                    CompileCode("" + returndata.Replace("$CodeStart", string.Empty));
                }
                else
                {
                    _readData = "" + returndata;
                    Msg();
                }
            }
        }
