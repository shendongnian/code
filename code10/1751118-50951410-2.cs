    var row = 0;
    using (var fs = new FileStream("input/sample.txt", FileMode.Open)
    using (var sr = new StreamReader(fs))
    {
        Console.WriteLine(fs.CanSeek);
        while (!sr.EndOfStream)
        {
            try
            {
                var line = sr.ReadLine();
                if (line.StartsWith("#"))
                    throw new IOException();
                row++;
                Console.WriteLine(line);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                // Reset to the line where the exception happened
                fs.Seek(0, SeekOrigin.Begin);
                sr.DiscardBufferedData();
                for (var i = 0; i < row; i++)
                    sr.ReadLine();
            }
        }
    }
