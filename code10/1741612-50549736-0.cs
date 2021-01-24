    string line;
    using (StreamReader sr = new StreamReader(@"C:\config.ini"))
    {
         line = sr.ReadToEnd();
    }
    
    
    Regex x = new Regex("(\\DBServer\\=)(.*?)(\n|\r|\r\n)");
    string repl = IP;
    string Result = x.Replace(line, "DBServer=" + repl + "$3");
    using (StreamWriter writer =
         new StreamWriter(@"C:\config.ini"))
    {
         writer.Write(Result);
    }
