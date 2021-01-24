    private void pingAllIPinOneShot()
        {
            int i = 0;
            try
            {
                
                PingTest C_ping = new PingTest();
                string[] lines = File.ReadAllLines(_hostFilePath, Encoding.UTF8);
                foreach (var line in lines)
                {
                    i = i + 1;
                    if (line != " " && line != "")
                    {
                        string strResult = Regex.Replace(line, @"\s+", " ");
                        char isHostCommented = strResult[0];
                        if (isHostCommented != '#') // assuming # at begining as commented server
                        {
                            string IPval = Before(strResult, " ");
                            string serverVal = After(strResult, " ");
                            string stat = PingAddr.GetPingAddr(serverVal);
                            if (stat != "Fail")
                            {
                                Dispatcher.BeginInvoke(new Action(() =>
                                {
                                    listBox1.Items.Remove(line);
                                    listBox1.Items.Add(new ListBoxItem { Content = line, Background = Brushes.GreenYellow });
                                }), DispatcherPriority.Background);
                            }
                            else
                            {
                                Dispatcher.BeginInvoke(new Action(() =>
                                {
                                    listBox1.Items.Remove(line);
                                    listBox1.Items.Add(new ListBoxItem { Content = line, Background = Brushes.IndianRed });
                                }), DispatcherPriority.Background);
                            }
                            Thread.Sleep(800); // delay to slow down the spreed
                        }
                    }
                }
                MessageBox.Show("Ping Test all Done");
            }
            catch (Exception EX)
            {
                MessageBox.Show("Failed on counter " + i + " " + EX.Message);
            }
        }
