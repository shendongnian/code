                    var ipAddress = "XXX.XXX.XXX.XXX";
                    var port = 9100;
                    var fle = "file.pdf";
                    var data = System.IO.File.ReadAllBytes(fle);
                    var client = new System.Net.Sockets.TcpClient();
                    client.Connect(ipAddress, port);
                    var stream = client.GetStream();
                    stream.Write(data, 0, data.Length);
                    client.Close();
