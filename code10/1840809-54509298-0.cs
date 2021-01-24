    public string GetReading()
    {
        try
        {
            Task.Delay(300).Wait(); //MXu
            byte[] i2CReadBuffer = new byte[20];
            _device.Read(i2CReadBuffer);
            
            string answer_string = "";
            bool got_error = false;
            int bufsize = i2CReadBuffer.Length;
            for(int i =0;i<bufsize;i++)
            {
                Debug.WriteLine(i2CReadBuffer[i].ToString("X"));
            }
            Debug.WriteLine("");
            switch (i2CReadBuffer[0]) //first character denotes I2C reception status
            {
                case 1:
                    i2CReadBuffer[0] = 0;
                    answer_string = Encoding.UTF8.GetString(i2CReadBuffer).Replace("\0", string.Empty);
                    // does it match ?L,1  .... if so , makegot_error to true, even though it isn't an error.
                    Regex regex = new Regex(@"\\?L,[0-9]*,?T?");
                    Match match = regex.Match(answer_string);
                    if (match.Success)
                    {
                        got_error = true;
                    }
                    break;
                case 2:
                case 254:
                case 255:
                default:
                    got_error = true;
                    break;
            }
       }
       catch(Exception ex)
       {
            Debug.WriteLine(ex.Message);
       }
    }
