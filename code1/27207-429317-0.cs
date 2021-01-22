        Process[] p = Process.GetProcessesByName("myprocess.exe");
        StreamReader sr = new StreamReader(p[0].StandardOutput);
        while (sr.BaseStream.CanRead)
        {
            Console.WriteLine(sr.ReadLine());
        }
