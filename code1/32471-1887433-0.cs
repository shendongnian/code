    static string getInternetConnectionIP()
    {
        using (Process route = new Process())
        {
            ProcessStartInfo startInfo = route.StartInfo;
            startInfo.FileName = "route.exe";
            startInfo.Arguments = "print 0.0.0.0";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            route.Start();
            using (StreamReader reader = route.StandardOutput)
            {
                string line;
                do
                {
                    line = reader.ReadLine();
                } while (!line.StartsWith("          0.0.0.0"));
                // the interface is the fourth entry in the line
                return line.Split(new char[] { ' ' },
                                  StringSplitOptions.RemoveEmptyEntries)[3];
            }
        }
    }
