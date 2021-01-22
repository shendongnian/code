    /// <summary>
    /// Return the first process id with matching values in the command line.
    /// </summary>
    /// <param name="args">
    /// Values in the command line to match (case insensitive).
    /// </param>
    /// <returns>
    /// The process id of the first matching process found; null on no match.
    /// </returns>
    public static int? ProcessIdOf(params string[] args)
    {
        using (var mos = new ManagementObjectSearcher(
            "SELECT ProcessId,CommandLine FROM Win32_Process"))
        {
            foreach (ManagementObject mo in mos.Get())
            {
                var commandLine = (string)mo["CommandLine"];
                for (int i = 0;; ++i)
                {
                    if (i == args.Length)
                    {
                        return int.Parse(mo["ProcessId"].ToString());
                    }
                    if (commandLine.IndexOf(
                           args[i], 
                           StringComparison.InvariantCultureIgnoreCase) == -1)
                    {
                        break;
                    }
                }
            }
        }
        return null;
    }
