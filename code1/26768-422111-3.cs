    bool bOk = false;
    try
    {
        new System.IO.FileInfo(fileName);
        bOk = true;
    }
    catch (ArgumentException) { }
    catch (System.IO.PathTooLongException) { }
    catch (NotSupportedException) { }
    if (!bOk)
    {
        ...
    }
    else
    {
        ...
    }
