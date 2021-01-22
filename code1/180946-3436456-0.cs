    string input ....
    int numOfBytes = input.Length / 8;
    byte[] bytes = new byte[numOfBytes];
    for(int i = 0; i < numOfBytes; ++i)
    {
        bytes[i] = Convert.ToByte(input.Substring(8 * i, 8), 2);
    }
    File.WriteAllBytes(fileName, bytes);
