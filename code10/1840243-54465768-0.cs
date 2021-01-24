    public Image LocalProfileImage;
    public void ShowMediaPicker()
    {
        if (Application.isEditor)
        {
            // Do something else, since the plugin does not work inside the editor
        }
        else
        {
            NativeGallery.GetImageFromGallery((path) =>
            {
                UploadNewProfileImage(path);
                Texture2D texture = NativeGallery.LoadImageAtPath(path);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }
                LocalProfileImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            });
        }
    }
