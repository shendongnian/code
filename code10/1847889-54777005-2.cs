    using System.IO;
    void SavePicture(byte[] texture)
    {
        string path = GetExternalStoragePath() + "/picture";
        string fileName = "picture.png";
    
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    
        File.WriteAllBytes(path + "/" + fileName, texture);
    }
    
    string GetExternalStoragePath()
    {
        AndroidJavaClass env = new AndroidJavaClass("android.os.Environment");
        AndroidJavaObject dir = env.CallStatic<AndroidJavaObject>("getExternalStorageDirectory");
        return dir.Call<string>("toString");
    }
