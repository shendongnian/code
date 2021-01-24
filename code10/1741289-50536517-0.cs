        string progToRun = "C:\\Dev\\hello.py";
        int param1 = 42; float param2 = 0.25f;
 
        Process proc = new Process();
        proc.StartInfo.FileName = "python.exe";
        proc.StartInfo.RedirectStandardOutput = true;
        proc.StartInfo.UseShellExecute = false;
             
        // call hello.py to concatenate passed parameters
        proc.StartInfo.Arguments = string.Concat(progToRun, " ", param1.ToString(), " ", param2.ToString());
        proc.Start();
 
        StreamReader sReader = proc.StandardOutput;
        string[] output = sReader.ReadToEnd().Split({'\r'});
 
        foreach (string s in output)
            Console.WriteLine(s);
 
        proc.WaitForExit();
