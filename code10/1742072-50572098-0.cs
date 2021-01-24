    public static byte[] Parse(string data)
    {
                var count = data.Length / 8;
                var needle = 0;
                List<byte> result = new List<byte>(); //Inefficient but I'm being lazy 
    
                for (int i = 0; i < count; i++)
                {
                    char[] buffer = new char[8];
                    data.CopyTo(needle, buffer, 0, buffer.Length);
    
                    //To get around the odd number when adding the prefixed count byte, send the hex string to the convert method separately.
                    var bytes = ConvertHexStringToByteArray(new string(buffer)); //Taken From https://stackoverflow.com/a/8235530/6574422
    
                    //As the count is less than 255, seems safe to parse to single byte
                    result.Add(byte.Parse((i + 1).ToString()));
                    result.AddRange(bytes);
    
                    needle += 8;
                }
    
                return result.ToArray();
    }
