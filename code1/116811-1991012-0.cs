    string content = string.Empty;
    using (StreamReader sr = new StreamReader("C:\\sample.txt"))
    {
        content = sr.ReadToEnd();
    }
    using (StreamWriter sw = new StreamWriter("C:\\Sample1.txt"))
    {
        sw.Write(content);
    }
