    IEnumerator RunDbCode(string fileName)
    {
        //Where to copy the db to
        string dbDestination = Path.Combine(Application.persistentDataPath, "data");
        dbDestination = Path.Combine(dbDestination, fileName);
    
        //Check if the File do not exist then copy it
        if (!File.Exists(dbDestination))
        {
            //Where the db file is at
            string dbStreamingAsset = Path.Combine(Application.streamingAssetsPath, fileName);
    
            byte[] result;
    
            //Read the File from streamingAssets. Use WWW for Android
            if (dbStreamingAsset.Contains("://") || dbStreamingAsset.Contains(":///"))
            {
                WWW www = new WWW(dbStreamingAsset);
                yield return www;
                result = www.bytes;
            }
            else
            {
                result = File.ReadAllBytes(dbStreamingAsset);
            }
            Debug.Log("Loaded db file");
    
            //Create Directory if it does not exist
            if (!Directory.Exists(Path.GetDirectoryName(dbDestination)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(dbDestination));
            }
    
            //Copy the data to the persistentDataPath where the database API can freely access the file
            File.WriteAllBytes(dbDestination, result);
            Debug.Log("Copied db file");
        }
    
        try
        {
            //Tell the db final location for debugging
            Debug.Log("DB Path: " + dbDestination.Replace("/", "\\"));
            //Add "URI=file:" to the front of the url beore using it with the Sqlite API
            dbDestination = "URI=file:" + dbDestination;
    
            //Now you can do the database operation below
            //open db connection
            var connection = new SqliteConnection(dbDestination);
            connection.Open();
    
            var command = connection.CreateCommand();
            Debug.Log("Success!");
        }
        catch (Exception e)
        {
            Debug.Log("Failed: " + e.Message);
        }
    }
