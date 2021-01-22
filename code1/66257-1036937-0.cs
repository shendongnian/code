    StreamReader rr = File.OpenText("C:/1.txt");
    string input = null;
    char[] seps = { ' ' };
    while ((input = rr.ReadLine()) != null)
    {    
        string[] sd = input.Split(seps, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < sd.Length; i++)
        {
            textBox4.AppendText(sd[i] + "\r\n");
            
            if (sd[i].Contains("/"))
            {
                // The string contains a / character; assume it is a date
                textBox1.AppendText(sd[i] + "\r\n");
            }
            else if (sd[i].Length == 8)
            {
                //The time is of 8 characters in length. ex:00:04:09
                textBox2.AppendText(sd[i] + "\r\n");
            }
            else if (sd[i].Length == 11)
            {
                //The phone is of 11 characters in length. ex:9480455302#
                textBox3.AppendText(sd[i] + "\r\n");
            }
        }                
     }
