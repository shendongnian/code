    void GetImage()
    {
        if (path != null)
        {
            StartCoroutine(UpdateImage());
        }
    }
    
    IEnumerator UpdateImage()
    {
        WWW www = new WWW("file:///" + path);
        yield return www;
        image.texture = www.texture;
    }
