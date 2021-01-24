    private async void StartDownload(BackgroundTransferPriority priority)
    {
        // Validating the URI is required since it was received from an untrusted source (user input).
        // The URI is validated by calling Uri.TryCreate() that will return 'false' for strings that are not valid URIs.
        // Note that when enabling the text box users may provide URIs to machines on the intrAnet that require
        // the "Home or Work Networking" capability.
        Uri source;
        if (!Uri.TryCreate(serverAddressField.Text.Trim(), UriKind.Absolute, out source))
        {
            rootPage.NotifyUser("Invalid URI.", NotifyType.ErrorMessage);
            return;
        }
    
        string destination = fileNameField.Text.Trim();
    
        if (string.IsNullOrWhiteSpace(destination))
        {
            rootPage.NotifyUser("A local file name is required.", NotifyType.ErrorMessage);
            return;
        }
    
        StorageFile destinationFile;
        try
        {
            destinationFile = await KnownFolders.PicturesLibrary.CreateFileAsync(
                destination,
                CreationCollisionOption.GenerateUniqueName);
        }
        catch (FileNotFoundException ex)
        {
            rootPage.NotifyUser("Error while creating file: " + ex.Message, NotifyType.ErrorMessage);
            return;
        }
    
        BackgroundDownloader downloader = new BackgroundDownloader();
        DownloadOperation download = downloader.CreateDownload(source, destinationFile);
    
        Log(String.Format(CultureInfo.CurrentCulture, "Downloading {0} to {1} with {2} priority, {3}",
            source.AbsoluteUri, destinationFile.Name, priority, download.Guid));
    
        download.Priority = priority;
    
        // Attach progress and completion handlers.
        await HandleDownloadAsync(download, true);
    }
