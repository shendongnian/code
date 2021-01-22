       if ((compilationSection != null) && !string.IsNullOrEmpty(compilationSection.TempDirectory))
    {
        path = compilationSection.TempDirectory;
        compilationSection.GetTempDirectoryErrorInfo(out tempDirAttribName, out configFileName, out configLineNumber);
    }
    if (path != null)
    {
        path = path.Trim();
        if (!Path.IsPathRooted(path))
        {
            path = null;
        }
        else
        {
            try
            {
                path = new DirectoryInfo(path).FullName;
            }
            catch
            {
                path = null;
            }
        }
        if (path == null)
        {
            throw new ConfigurationErrorsException(SR.GetString("Invalid_temp_directory", new object[] { tempDirAttribName }), configFileName, configLineNumber);
        }
