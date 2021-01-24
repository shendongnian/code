    using (var fs = new FileStream(jsFile, FileMode.Open))
    {
        int i = 0;
        int readByte;
        while ((readByte = fs.ReadByte()) != -1)
        {
            if (matchBytes[i] == readByte)
            {
                i++;
            }
            else
            {
                i = 0;
            }
            if (i == matchBytes.Length)
            {
                Console.WriteLine("It found between {0} and {1}.",
                            fs.Position - matchBytes.Length, fs.Position);
                //Desired string length in charachters
                const int DESIRED_STRING_LENGTH = 5;
                Console.WriteLine(GetString(fs, fs.Position, DESIRED_STRING_LENGTH, Encoding.Unicode));
                break;
            }
        }
    }
