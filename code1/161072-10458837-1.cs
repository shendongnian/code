    string configPath = val.ToString();
    bool dirExists = false;
    if (Directory.Exists(configPath))
    {
        dirExists = true;
    }
    else
    {
        _logger.Warn("The path for service {0} doesn't exist: {1}", serviceName, configPath);
        StringBuilder configPathBuilder = new StringBuilder(configPath.Length);
        // Do this to remove any dodgy characters in the path like a ? at end
        char[] inValidChars = Path.GetInvalidPathChars();
        foreach (Char c in configPath.ToCharArray())
        {
            if (inValidChars.Contains(c) == false && c < 128)
            {
                configPathBuilder.Append(c);
            }
            else
            {
                _logger.Warn("An invalid path was character was found in the path: {0} {1}", c, (int)c);
            }
        }
        configPath = configPathBuilder.ToString();
        if (Directory.Exists(configPath))
        {
            dirExists = true;
        }
    }
