    var row = 0;
    while (true)
    {
        using (var fs = new FileStream("input/sample.txt", FileMode.Open))
        using (var sr = new StreamReader(fs))
        {
            for (var i = 0; i < row; i++)
                sr.ReadLine();
            try
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (line.StartsWith("#"))
                        throw new IOException();
                    row++;
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            if (sr.EndOfStream)
                break;
        }
    }
