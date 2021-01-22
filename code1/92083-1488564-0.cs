    byte[] text = System.Text.Encoding.Unicode.GetBytes("test");
    FileStream fs = new FileStream("C:\\test.txt", FileMode.Create);
    BinaryWriter writer = new BinaryWriter(fs);
    writer.Write(text);
    writer.Close();
