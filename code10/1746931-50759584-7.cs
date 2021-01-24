        string temp = "";
                    while (_serialPort.BytesToRead > 0)
                    {
                        temp += string.Format("{0:X2} ", _serialPort.ReadByte());
                    }
        
                    string sNosapce = Regex.Replace(temp, " ", ""); // remove white spaces from string
                    string wantedString = sNosapce.Substring(0, 6); // take the first 6 chars
                    textBox1.Text = wantedString.Insert(3, ","); // insert the comma in the wanted index
    temp = "";
