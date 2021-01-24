        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort1 = (SerialPort)sender;
 
                    var rt1 = new RichTextBox();
                    var rt2 = new RichTextBox();
                    var rt3 = new RichTextBox();
                    string blah = serialPort1.ReadLine();
                    var lst = blah.Split('E').ToList();
                    foreach (var item in lst)
                        if (item.Trim().StartsWith("S"))
                            rt1.AppendText($"Steps: {item.Remove(0, 1)} \n");
                        else if (item.Trim().StartsWith("T"))
                            rt2.AppendText($"Temperature: {item.Remove(0, 1)} \n");
                        else if (item.Trim().StartsWith("P"))
                            rt3.AppendText($"Pulse: {item.Remove(0, 1)} \n");
                    
            }
        
