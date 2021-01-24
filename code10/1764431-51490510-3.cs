    public static void Main()
    {
        using (var fs = new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
        {
            using (var sw = new StreamWriter(fs, Encoding.ASCII, 1024, true))
            using (var sr = new StreamReader(fs, Encoding.ASCII, false, 1024, true))
            {
                sw.WriteLine("Hi");
                sw.Flush();           //Make sure everything is fully written to the file.
                fs.Position = 0;      //Go back to the beginning of the file, so we can read it.
                Console.WriteLine(sr.ReadLine()); //Hi
            }
            
        }
    }
