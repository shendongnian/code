        Process[] p = Process.GetProcessesByName("myprocess.exe");
        StreamReader sr = p[0].StandardOutput;
        while (sr.BaseStream.CanRead)
        {
            Console.WriteLine(sr.ReadLine());
        }
