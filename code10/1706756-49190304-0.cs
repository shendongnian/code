    //if file doesn't exist then save it for fututre reference
        if (!File.Exists(_FileLocation + texName))
        {
            byte[] bytes;
            if (Path.GetExtension(texName) == ".png")
            {
                bytes = texture.EncodeToPNG();
            }
            else
            {
                bytes = texture.EncodeToJPG();
            }
            File.WriteAllBytes(Application.persistentDataPath + texName, bytes);
        }
