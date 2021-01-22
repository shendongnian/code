     public static void step1a()
     {
        string betaFilePath = @"C:\ext.txt";
        string[] lines = File.ReadAllLines(betaFilePath);
        using (StreamWriter writer = new StreamWriter(File.Create(@"C:\xt2.txt")))
        {
            string buffer = null;
            foreach (string line in lines)
            {
                if (!line.StartsWith(begins))
                {
                    writer.WriteLine(buffer + line);
                    buffer = null;
                }
                else
                {
                    if (buffer != null)
                        writer.WriteLine(buffer);
                    buffer = line;
                }
                
            }
            if(buffer != null)
                Console.Out.WriteLine(buffer);
        } 
    } 
