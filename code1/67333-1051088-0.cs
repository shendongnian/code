    private void DoSomethingWithFile(string filename)
    {
        // Note: try/catch doesn't need to surround the whole method...
        if (File.Exists(filename))
        {
            try
            {
                // do something involving the file
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("Cannot do something with file '{0}'.", ex);
            }
        }
    }
