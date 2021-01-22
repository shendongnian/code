    using (FileStream stream = File.OpenRead(filePath))
    {
        int size = 2048;
        byte[] data = new byte[2048];
        size = stream.Read(data,0,size);
		
        if (data[3] == 8)
        {
            List<byte> byteList = new List<byte>();
					
            int i = 10;
            while (data[i] != 0)
            {
                byteList.Add(data[i]);
                i++;
            }
            string test = System.Text.ASCIIEncoding.ASCII.GetString(byteList.ToArray());
            Console.WriteLine(test);
				
        }
    }
