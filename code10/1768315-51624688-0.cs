                    client.UseDefaultCredentials = true;
                    byte[] responseBytes = client.DownloadData(new Uri("<your web api url>/accounts(3C2D2712-E43F-E411-9402-005056AB452C)")); 
                    string response = Encoding.UTF8.GetString(responseBytes);
                    // parse the json response 
                }
