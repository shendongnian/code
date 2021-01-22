    System.IO.FileInfo[] fi = di.GetFiles(strUser + "*.*");
        for (i = 0; i <= fi.Length - 1; i++)
        {
    
            System.IO.File.Delete(strFolder + "\\" + strUniqueFn);
        }
