    using(StreamWriter writer = File.Create(@"C:\xt2.txt")) 
    {
        foreach (string line in lines)
        {
            if (line.StartsWith(begins))            
                writer.WriteLine();  //Close the previous line
            writer.Write(line);
        }
    }
