    int databases = streamer.Read(buffers, 0, buffers.Length);
                    string data = Encoding.Unicode.GetString(buffers, 0, databases);
                    if (data == "Response_Command_329873123709123")
                    {
                        byte[] datacen = new byte[client.ReceiveBufferSize];
                        int main = streamer.Read(datacen, 0, datacen.Length);
                        var message = Encoding.Unicode.GetString(datacen, 0, main);
                        MessageBox.Show(message, "Client Response");
                    }
