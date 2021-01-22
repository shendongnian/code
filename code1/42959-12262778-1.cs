    using System.Diagnostics;
    public static string[] GetComputers()
    {
        //Process that retrieves the net view >> list of computers on the network
        Process proc = new Process();
        proc.StartInfo.FileName = "net.exe";
        proc.StartInfo.CreateNoWindow = true;
        proc.StartInfo.Arguments = "view";
        proc.StartInfo.RedirectStandardOutput = true;
        proc.StartInfo.UseShellExecute = false;
        proc.Start();
        //Reads the output of the net view.
        StreamReader sr = new StreamReader(proc.StandardOutput.BaseStream);
        string line = "";
        List<string> names = new List<string>();
        while ((line = sr.ReadLine()) != null)
        {
            if (line.StartsWith(@"\\"))
                names.Add(line.Substring(2).Split(' ')[0].TrimEnd());
        }
        sr.Close();
        proc.WaitForExit();
        //Array that contains computer names
        string[] computerNames = new string[names.Capacity];
        int i = 1;
        //Adds computers names to the list view
        foreach (string name in names)
        {
            computerNames[i] = name;
            i++;
        }
        return computerNames;
    }
