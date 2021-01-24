    void Start()
    {
        StartCoroutine(GetRequest("http:///www.yoururl.com"));
    }
    
    IEnumerator GetRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();
    
        if (uwr.isHttpError || uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Downloaded");
    
            string dataFileName = "FileName";
            string tempPath = Path.Combine(Application.persistentDataPath, "Audio");
            tempPath = Path.Combine(tempPath, dataFileName + ".mp3");
    
            SaveFile(tempPath, uwr.downloadHandler.data);
        }
    }
    
    void SaveFile(string path, byte[] fileBytes)
    {
        //Create Directory if it does not exist
        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }
    
        try
        {
            File.WriteAllBytes(path, fileBytes);
            Debug.Log("Saved Data to: " + path.Replace("/", "\\"));
        }
        catch (Exception e)
        {
            Debug.LogWarning("Failed To Save Data to: " + path.Replace("/", "\\"));
            Debug.LogWarning("Error: " + e.Message);
        }
    }
