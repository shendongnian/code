    NetworkStream ns = server.GetStream();
    openConnection = True;
    			Task.Factory.StartNew(() => 
    				{
    					while (openConnection)
    					{
    						ns.Read(data, 0, data.Length);
    						var stringData = Encoding.ASCII.GetString(data, 0, 1024);
    						dataToAdd.Add(stringData);
    						foreach (var list in dataToAdd)
    						{
    							txt_BarcodeDisplay.Text += list + Environment.NewLine;
    						}
    						Thread.Sleep(2000);
    					}
    				}
    			);
