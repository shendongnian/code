    try
    {
        StorageFile file = rootPage.sampleFile;
        if (file != null)
        {
            StringBuilder outputText = new StringBuilder();
    
            // Get music properties
            MusicProperties musicProperties = await file.Properties.GetMusicPropertiesAsync();
            outputText.AppendLine("Album: " + musicProperties.Album);
            outputText.AppendLine("Rating: " + musicProperties.Rating);
        }
    }
    // Handle errors with catch blocks
    catch (FileNotFoundException)
    {
     // For example, handle a file not found error
    }
