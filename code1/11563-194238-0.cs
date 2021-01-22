    static Regex pathArgumentsRegex = new Regex(@"(%\d+)|(""%\d+"")", RegexOptions.ExplicitCapture);
    static string GetPathAssociatedWithFileExtension(string extension)
    {
        RegistryKey extensionKey = Registry.ClassesRoot.OpenSubKey(extension);
        if (extensionKey != null)
        {
            object applicationName = extensionKey.GetValue(string.Empty);
            if (applicationName != null)
            {
                RegistryKey commandKey = Registry.ClassesRoot.OpenSubKey(applicationName.ToString() + @"\shell\open\command");
                if (commandKey != null)
                {
                    object command = commandKey.GetValue(string.Empty);
                    if (command != null)
                    {
                        return pathArgumentsRegex.Replace(command.ToString(), "");
                    }
                }
            }
        }
        return null;
    }
