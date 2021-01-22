    using(StreamWriter writer = File.Create(@"C:\xt2.txt")) 
    {
        foreach (string line in lines)
        {
            if (line.StartsWith(begins))
            {
                writer.WriteLine(@"C:\xt2.txt",line);
            }
            else
            {
                string line2 = line.Replace(Environment.NewLine, " "); //This is useless
                writer.Write(line2);
            }
        }
    }
