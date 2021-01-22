    bool success = false;
    RegistryKey httpKey = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command");
    if (httpKey != null && httpKey.GetValue(string.Empty) != null)
    {
        string cmd = httpKey.GetValue(string.Empty) as string;
        if (cmd != null)
        {
            try
            {
                if (cmd.Length > 0)
                {
                    string[] splitStr;
                    string fileName;
                    string args;
                    if (cmd.Substring(0,1) == "\"")
                    {
                        splitStr = cmd.Split(new string[] { "\" " }, StringSplitOptions.None);
                        fileName = splitStr[0] + "\"";
                        args = cmd.Substring(splitStr[0].Length + 2);
                    }
                    else
                    {
                        splitStr = cmd.Split(new string[] { " " }, StringSplitOptions.None);
                        fileName = splitStr[0];
                        args = cmd.Substring(splitStr[0].Length + 1);
                    }
                    System.Diagnostics.Process.Start(fileName, args.Replace("%1","http://stackoverflow.com"));
                    success = true;
                }
            }
            catch (Exception)
            {
                success = false;
            }
        }
        httpKey.Close();
    }
