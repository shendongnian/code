    public static void CopyTo(this Stream input, Stream output)
    {
        using (input)
        using (output)
        {
            byte[] buffer = new byte[1024];
            for (int amountRead = input.Read(buffer, 0, buffer.Length); amountRead > 0; amountRead = input.Read(buffer, 0, buffer.Length))
            {
                output.Write(buffer, 0, amountRead);
            }                
        }
    }
