    public RawImage image;
    public void OpenExplorer()
    {
        SimpleFileBrowser.FileBrowser.SetFilters(true, ".txt", ".jpg", ".png", ".mp4");
        SimpleFileBrowser.FileBrowser.ShowLoadDialog((path) => { StartCoroutine(UpdateImage(path)); }, null, false, null, "Select File", "Select");
    }
    IEnumerator UpdateImage(string pfad)
    {
        if (pfad != null)
        {
            WWW www = new WWW(pfad);
            //WAIT UNTIL REQUEST IS DONE!
            yield return www;
            //Check for error
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.error);
            }
            else
            {
                image.texture = www.texture;
                var texWidth = www.texture.width;
                var texHeight = www.texture.height;
                if (texWidth > texHeight)
                {
                    GetComponent<RectTransform>().sizeDelta = new Vector2(1920 / 2, 1080 / 2);
                }
                if (texWidth < texHeight)
                {
                    GetComponent<RectTransform>().sizeDelta = new Vector2(1080 / 2, 1920 / 2);
                }
            }
        }
    }
