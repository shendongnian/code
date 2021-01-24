    Windows.Storage.ApplicationDataContainer roamingSettings;
    Windows.Storage.StorageFolder roamingFolder;
    string donnees = Newtonsoft.Json.JsonConvert.SerializeObject(anobject);
    if (UseRoaming)
    {
        roamingFolder = Windows.Storage.ApplicationData.Current.RoamingFolder;
        roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;
    }
    else
    {
        roamingFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        roamingSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
    }
    StorageFile sampleFile = await roamingFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
    using (IRandomAccessStream textStream = await sampleFile.OpenAsync(FileAccessMode.ReadWrite))
    {
        using (DataWriter textWriter = new DataWriter(textStream))
        {
            textWriter.WriteString(donnees);
            await textWriter.StoreAsync();
        }
    }
