            private async void RecvAsync()
            {
                byte[]          key     = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
                byte[]          iv      = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
                RijndaelManaged crypto  = new RijndaelManaged();
                CryptoStream    cStream = new CryptoStream(_stream, crypto.CreateDecryptor(key, iv), CryptoStreamMode.Read);
                int bytesRead = 0;
                byte[] bytes = new byte[8];
                List<byte> buffer = new List<byte>();
                cStream.Read( bytes, 0, 4 );
                //await _stream.ReadAsync(bytes, 0, 4, _cancelToken.Token);
                int size = BitConverter.ToInt32(bytes, 0);
                do
                {
                    bytesRead = cStream.Read( bytes, 0, 8 );
                    buffer.AddRange(bytes.Take(bytesRead));
     
                } while ( buffer.Count() < size );
                try
                {
                        
                    if(buffer.Count() >= 8)
                    {
                        int id   = BitConverter.ToInt32( buffer.ToArray(), 0 );
                        int type = BitConverter.ToInt32( buffer.ToArray(), 4 );
                        UTF8Encoding utf  = new UTF8Encoding();
                        string  body = utf.GetString( buffer.ToArray(), 8, size - 8 );
                        Packet packet = new Packet( id, (ServerDataType)type, body );
                        ProcessPacket( packet );
                    }
                }
                catch ( Exception ) { break; }
            }
