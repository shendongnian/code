    void OnGUI()
    {
        var loadPlayer = GUILayout.Button("Load Player");
        if (loadPlayer)
        {
            Debug.Log("I log to the console just fine");
            LoadAvatarTexture("http://dev-avatars.gamesmart.com/default.png");
        }
        //Check if request is done then get the texture
        if (www != null && www.isDone)
        {
            if (string.IsNullOrEmpty(www.error))
                avatarTexture = www.texture;
            else
                Debug.Log(www.error);
            //Reset
            www = null;
        }
        if (avatarTexture != null)
        {
            float aspect = (float)avatarTexture.width / (float)avatarTexture.height;
            Rect previewRect = GUILayoutUtility.GetAspectRect(aspect, GUILayout.Width(100), GUILayout.ExpandWidth(true));
            GUI.DrawTexture(previewRect, avatarTexture, ScaleMode.ScaleToFit, true, aspect);
        }
    }
    WWW www;
    void LoadAvatarTexture(string url)
    {
        Debug.Log("I do not log to the console");
        www = new WWW(url);
        if (string.IsNullOrEmpty(www.error))
            avatarTexture = www.texture;
        else
            Debug.Log(www.error);
    }
