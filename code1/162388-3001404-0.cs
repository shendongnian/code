    System.IO.FileStream fs = null;
    System.IO.StreamReader sr = null;
    try{
        fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        sr = new System.IO.StreamReader(fs);
        res = sr.ReadToEnd();
    }
    catch (System.Exception ex)
    {
        HandleEx(ex);
    }
    finally
    {
       if (sr != null)  sr.Close();
       if (fs != null)  fs.Close();
    }
