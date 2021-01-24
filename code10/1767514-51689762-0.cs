    public string url;
    
    IEnumerator Start()
    {
        ///url = Application.dataPath + "/StreamingAssets/shareImage.png";
        url = Path.Combine(Application.streamingAssetsPath, "shareImage.png");
    
        byte[] imgData;
        Texture2D tex = new Texture2D(2, 2);
    
        //Check if we should use UnityWebRequest or File.ReadAllBytes
        if (url.Contains("://") || url.Contains(":///"))
        {
            UnityWebRequest www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();
            imgData = www.downloadHandler.data;
        }
        else
        {
            imgData = File.ReadAllBytes(url);
        }
        Debug.Log(imgData.Length);
    
        //Load raw Data into Texture2D 
        tex.LoadImage(imgData);
    
        //Convert Texture2D to Sprite
        Vector2 pivot = new Vector2(0.5f, 0.5f);
        Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), pivot, 100.0f);
    
        //Apply Sprite to SpriteRenderer
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprite;
    }
