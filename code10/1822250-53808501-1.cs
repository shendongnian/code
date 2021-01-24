    Process.Start(sigCheckProcess).WaitForExit();
    
    using (System.IO.StreamWriter writer = new System.IO.StreamWriter("output.txt")) // output txt file.
    {
        using (System.IO.StreamReader reader = new System.IO.StreamReader(Path.Combine(@"c:\temp\", "test.txt")))  // replaces sigCheckProcess.StandardOutput
        {
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                writer.WriteLine(line);
            }
        }
    }
