     string incomingData = string.Format("{0:X2} ", _serialPort.ReadByte()); // bytes coming from serial port
                string sNosapce = Regex.Replace(incomingData, " ", ""); // remove white spaces from string
                if (sNosapce.Length >= 6) // this will check if the string is long enough to operate
                {
                    
                    string wantedString = sNosapce.Substring(0, 6); // take the first 6 chars
                    textBox1.Text = wantedString.Insert(3, ","); // insert the comma in the wanted index
                }
