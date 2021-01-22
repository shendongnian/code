    private static bool CompareFiles(string file1, string file2)
    {
        var fsFile1 = new System.IO.FileStream(file1, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        var fsFile2 = new System.IO.FileStream(file2, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        var md5 = new System.Security.Cryptography.MD5Cng();
        var md5File1 = md5.ComputeHash(fsFile1);
        var md5File2 = md5.ComputeHash(fsFile2);
        for (int i = 0; i < md5File1.Length; ++i)
        {
            if (md5File1[i] != md5File2[i])
                return false;
        }
        return true;
    }
