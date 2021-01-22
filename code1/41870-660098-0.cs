    string contents1;
    string contents2;
    using (FileStream fs1 = new FileStream("test.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    {
        using (var tr1 = new StreamReader(fs1))
        {
            using (FileStream fs2 = new FileStream("test.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var tr2 = new StreamReader(fs2))
                {
                    contents2 = tr2.ReadToEnd();
                    contents1 = tr1.ReadToEnd();
                }
            }
        }
    }
    
    Console.WriteLine(contents1);
    Console.WriteLine(contents2);
