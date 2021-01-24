    static void Main(string[] args)
    {
        System.Diagnostics.Process p = new System.Diagnostics.Process();
        p.StartInfo.FileName = "notepad.exe";
        for (int i = 0; i < 3; i++)
        {
            p.StartInfo.Arguments = $"d:\\text{i}.txt";
            p.Start();
            Console.WriteLine("Start run");
            p.WaitForExit();
            int result = p.ExitCode;
            Console.WriteLine("Return info:" + $"text{i}.txt created successfully!");
        }
    
        p.StartInfo.FileName = "explorer.exe";
        p.StartInfo.Arguments = "d:";
        p.Start();
    }
