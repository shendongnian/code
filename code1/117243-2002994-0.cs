    static void Main(string[] args)
    {
        List<Byte[]> strings = new List<byte[]>();
    
        using (TextReader tr = new StreamReader(@"C:\test.log"))
        {
            string s = tr.ReadLine();
            while (s != null)
            {
                strings.Add(Encoding.Convert(Encoding.Unicode, Encoding.UTF8, Encoding.Unicode.GetBytes(s)));
                s = tr.ReadLine();
            }
        }
    
        // Get strings back
        foreach( var str in strings)
        {
            Console.WriteLine(Encoding.UTF8.GetString(str));
        }
    }
