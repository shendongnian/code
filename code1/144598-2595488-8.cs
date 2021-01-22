    using (System.IO.FileStream input = new System.IO.FileStream(fileName,
                                        System.IO.FileMode.Open, 
                                        System.IO.FileAccess.Read))
    {
        byte[] buffer = new byte[input.Length];
        int readLength = 0;
        while (readLength < buffer.Length) 
            readLength += input.Read(buffer, readLength, buffer.Length - readLength);
        byte[] converted = Encoding.Convert(Encoding.GetEncoding("iso-8859-1"), 
                           Encoding.UTF8, buffer);
        using (System.IO.FileStream output = new System.IO.FileStream(outFileName,
                                             System.IO.FileMode.Create, 
                                             System.IO.FileAccess.Write))
        {
            output.Write(converted, 0, converted.Length);
        }
    }
