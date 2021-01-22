    using (FileStream fs = new FileStream("myLogFile.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    {
        using (StreamReader sr = new StreamReader(fs))
        {
            while (!fs.EndOfStream)
            {
                string line = fs.ReadLine();
                // Your code here
            }
        }
    }
