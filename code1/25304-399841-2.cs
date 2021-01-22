    StreamReader reader = new StreamReader(@"c:\test.txt"); //pick appropriate Encoding
    reader.BaseStream.Seek(0, SeekOrigin.End);
    int count = 0;
    while ((count < 10) && (reader.BaseStream.Position > 0))
    {
        reader.BaseStream.Position--;
        int c = reader.BaseStream.ReadByte();
        if (reader.BaseStream.Position > 0)
            reader.BaseStream.Position--;
        if (c == Convert.ToInt32('\n'))
        {
            ++count;
        }
    }
    string str = reader.ReadToEnd();
    string[] arr = str.Replace("\r", "").Split('\n');
    reader.Close();
