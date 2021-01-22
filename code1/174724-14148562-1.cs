     foreach (string s in SerialPort.GetPortNames())
            {
                com.Close(); // To handle the exception, in case the port isn't found and then they try again...
                bool portfound = false;
                    com.PortName = s;
                    com.BaudRate = 38400;
                    try
                    {
                        com.Open();
                        status.Clear();
                        status.Text += "Trying port: " + s+"\r";
                    }
                    catch (IOException c)
                    {
                        status.Clear();
                        status.Text += "Invalid Port"+"\r";
                        return;
                    }
                    catch (InvalidOperationException c1)
                    {
                      
                        status.Clear();
                        status.Text += "Invalid Port" + "\r";
                        return;
                    }
                    catch (ArgumentNullException c2)
                    {
                        // System.Windows.Forms.MessageBox.Show("Sorry, Exception Occured - " + c2);
                        status.Clear();
                        status.Text += "Invalid Port" + "\r";
                        return;
                    }
                    catch (TimeoutException c3)
                    {
                        //  System.Windows.Forms.MessageBox.Show("Sorry, Exception Occured - " + c3);
                        status.Clear();
                        status.Text += "Invalid Port" + "\r";
                        return;
                    }
                    catch (UnauthorizedAccessException c4)
                    {
                        //System.Windows.Forms.MessageBox.Show("Sorry, Exception Occured - " + c);
                        status.Clear();
                        status.Text += "Invalid Port" + "\r";
                        return;
                    }
                    catch (ArgumentOutOfRangeException c5)
                    {
                        //System.Windows.Forms.MessageBox.Show("Sorry, Exception Occured - " + c5);
                        status.Clear();
                        status.Text += "Invalid Port" + "\r";
                        return;
                    }
                    catch (ArgumentException c2)
                    {
                        //System.Windows.Forms.MessageBox.Show("Sorry, Exception Occured - " + c2);
                        status.Clear();
                        status.Text += "Invalid Port" + "\r";
                        return;
                    }
                    if (!portfound)
                    {
                        if (com.IsOpen) // Port has been opened properly...
                        {
                            com.ReadTimeout = 500; // 500 millisecond timeout...
                            sent.Text += "Attemption to open port " + com.PortName + "\r";
                            try
                            {
                                sent.Text += "Waiting for a response from controller: " + com.PortName + "\r";
                                string comms = com.ReadLine();
                                sent.Text += "Reading From Port " + com.PortName+"\r";
                                if (comms.Substring(0,1) == "A") // We have found the arduino!
                                {
                                    status.Clear();
                                    status.Text += s + com.PortName+" Opened Successfully!" + "\r";
                                    //com.Write("a"); // Sends 0x74 to the arduino letting it know that we are connected!
                                    com.ReadTimeout = 200; 
                                    com.Write("a");
                                    sent.Text += "Port " + com.PortName + " Opened Successfully!"+"\r";
                                    brbox.Text += com.BaudRate;
                                    comboBox1.Text = com.PortName;
                                    
                                }
                                else
                                {
                                    sent.Text += "Port Not Found! Please cycle controller power and try again" + "\r";
                                    com.Close();       
                                }
                            }
                            catch (Exception e1)
                            {
                                status.Clear();
                                status.Text += "Incorrect Port! Trying again...";
                                com.Close();
                            }
                        }
                  }
            }
