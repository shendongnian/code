    public IEnumerator LoadLocalizedText(SystemLanguage language, Action<bool> success)
    {
        localizedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, "localizedText_" + language + ".json");
        string dataAsJson;
        //Android
        if (filePath.Contains("://"))
        {
            WWW reader = new WWW(filePath);
            if (reader.text == null || reader.text == "")
                success(false);
            //Wait(Non blocking until download is done)
            while (!reader.isDone)
            {
                yield return null;
            }
            dataAsJson = reader.text;
        }
        //iOS
        else
        {
            dataAsJson = System.IO.File.ReadAllText(filePath);
        }
        LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);
        for (int i = 0; i < loadedData.items.Length; i++)
        {
            localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
        }
        Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + " entries");
        if (localizedText.Count == 0)
            success(false);
        else
        {
            isReady = true;
            success(true);
        }
    }
