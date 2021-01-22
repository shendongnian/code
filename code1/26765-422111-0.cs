    bool bOk = true;
    try
    {
      new System.IO.FileInfo(fileName);
    }
    catch (ArgumentException)
    {
      bOk = false;
    }
    if (!bOk)
    {
      ...
    }
