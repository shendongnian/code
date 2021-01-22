    using (System.IO.StreamReader sr = new System.IO.StreamReader("path"))
    {
        int fileNumber = 0;
        while (!sr.EndOfStream)
        {
            int count = 0;
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("other path" + ++fileNumber))
            {
                while (!sr.EndOfStream && ++count < 20000)
                {
                    sw.WriteLine(sr.ReadLine());
                }
            }
        }
    }
