    try {
        writer.WriteAttributeString("name", info.Name);
        [...]
    } catch (Exception ex) {
        // If is a permission error, ignore exception
        if (ex is UnauthorizedAccessException)
             return size;
        // custom error log
        string errorMsg = string.Format("Exception Folder : {0}, Error : {1}", info.FullName, ex.Message);
        Console.WriteLine(errorMsg);
        writer.WriteElementString("Error", errorMsg);
    }
