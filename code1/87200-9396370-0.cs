    private static bool isDirectory(string path)
    {
        bool result = true;
        System.IO.FileInfo fileTest = new System.IO.FileInfo(path);
        if (fileTest.Exists == true)
        {
            result = false;
        }
        else
        {
            if (fileTest.Extension != "")
            {
                result = false;
            }
        }
        return result;
    }
