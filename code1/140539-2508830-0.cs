    public void step1a()  
                {
            string begins = ("\"\\\"A\"");
            string betaFilePath = @"C:\ext.txt";
            string[] lines = File.ReadAllLines(betaFilePath);
            foreach (string line in lines)
            {
                if (line.StartsWith(begins))
                {
                 File.AppendAllText(@"C:\xt2.txt",line);
                 File.AppendAllText(@"C:\xt2.txt", "\n");
                }
                else
                {
                string line2 = line.Replace(Environment.NewLine, " ");
                File.AppendAllText(@"C:\xt2.txt",line2);
                }
    
            }
    
        }
