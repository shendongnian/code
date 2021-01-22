    System.IO.FileInfo fi = null;
    try
    {
      fi = new System.IO.FileInfo(fileName);
    }
    catch (ArgumentException) { }
    catch (System.IO.PathTooLongException) { }
    catch (NotSupportedException) { }
    if (ReferenceEquals(fi, null))
    {
      ...&#xD;// file name is not valid
    }
    else
    {
      ...&#xD;// file name is valid... May check for existence by calling fi.Exists.
    }
