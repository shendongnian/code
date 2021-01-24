    public void  comtest ()
            {
                SerialPort sport = new SerialPort("COM2", 9600, Parity.None, 8, StopBits.One);
                sport.Open();
                string Msg = "*HELLO WORLD*";
                string ogstring = Msg + " ";
                string mystring = "";
                string displaystring = "";
                for (int count = 0; count <= Msg.Length; count++)
                {
                    if (mystring == "")
                    {
                        mystring = ogstring;
                    }
                    if (mystring.Length > 20)
                    {
                        displaystring = mystring.Substring(0, 20);
                    }
                    else
                    {
                        displaystring = mystring;
                    }
                    sport.Write(new byte[] { 0x0A, 0x0D }, 0, 2);
                    sport.Write(displaystring);
                    System.Threading.Thread.Sleep(1000);
                    string s = mystring[0].ToString();
                    mystring = mystring.Substring(1);
                    mystring = mystring + s;
    
                    
                }
            }
