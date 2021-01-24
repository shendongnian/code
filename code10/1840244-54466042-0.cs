    public void GetTexture(string url, Action<Texture> onSuccess)
    {
        StartCoroutine (LoadTexture(url, onSuccess));
    }
    private IEnumerator LoadTexture(string url, Action<Texture> onSuccess)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
    
        if(www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else 
        {
            onSuccess?.Invoke(((DownloadHandlerTexture)www.downloadHandler).texture);
        }
    }
