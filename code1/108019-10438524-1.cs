    if (fileUpload.HasFile)
    {
        using (Stream fileStream = fileUpload.PostedFile.InputStream)
        using (StreamReader sr = new StreamReader(fileStream))
        {
            string idNum = null;
            while ((idNum = sr.ReadLine()) != null)
            {
                // Verify the line is in the expected id format
                if (Regex.IsMatch(idNum, this.InputRegex))
                {
                    // Do Stuff with input
                }
                else
                {
                    Log.LogDebug("{0}Invalid input format.", LoggingSettings.logPrefix);
                }
            }
        }
    
    }
    else
    {
        Log.LogDebug("{0}No file present.", LoggingSettings.logPrefix);
    }
