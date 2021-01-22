    System.IO.FileInfo fi = null;
    try {
      fi = new System.IO.FileInfo(fileName);
    }
    catch (ArgumentException) { }
    catch (System.IO.PathTooLongException) { }
    catch (NotSupportedException) { }
    if (ReferenceEquals(fi, null)) {
      // file name is not valid
    } else {
      // file name is valid... May check for existence by calling fi.Exists.
    }
