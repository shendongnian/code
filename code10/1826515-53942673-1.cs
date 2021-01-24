    `Firebase.Storage.StorageReference storageReference = 
    Firebase.Storage.FirebaseStorage.DefaultInstance.GetReferenceFromUrl("storage_url");
    storageReference.Child("resource_name").GetBytesAsync(1024*1024).
    ContinueWith((System.Threading.Tasks.Task<byte[]> task) =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.Log(task.Exception.ToString());
            }
            else
            {
                byte[] fileContents = task.Result;
                Texture2D texture = new Texture2D(1, 1);
                texture.LoadImage(fileContents);
                //if you need sprite for SpriteRenderer or Image
                Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f,texture.width, 
                texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                Debug.Log("Finished downloading!");
            }
        });`
