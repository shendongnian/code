    String[] content = { "large", "string", "array", "test" };
    MemoryStream ms = GetMemoryStream(content);
    using (FileStream fs = new FileStream(@"C:\Test.txt", FileMode.Create, FileAccess.ReadWrite))
    {
       ms.WriteTo(fs);
    }
    ms.Dispose();
--
    public static MemoryStream GetMemoryStream(String[] content)
    {
        MemoryStream ms = new MemoryStream();
        using (StreamWriter sw = new StreamWriter(ms, Encoding.Default, 1024, true))
        {
            foreach (String s in content)
                sw.WriteLine(s);
            sw.Flush();
        }
        return ms;
    }
