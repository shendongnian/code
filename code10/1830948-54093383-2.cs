    StorageFile dbFile = null;
    try
    {
        dbFile = await ApplicationData.Current
           .LocalFolder.GetFileAsync("ContactsDB.db");
        dbExists = true
    }
    catch (Exception)
    {
        //file does not exist
    }
    if (dbFile == null)
    {
       //copy db deployed with app
       var appDb = await StorageFile.GetFileFromApplicationUriAsync(
           new Uri("ms-appx:///ContactsDB.db")); 
       dbFile = await appDb.CopyAsync(
           ApplicationData.Current.LocalFolder);     
    }
    SQLiteConnection connection = new SQLiteConnection("ContactsDB.db");
