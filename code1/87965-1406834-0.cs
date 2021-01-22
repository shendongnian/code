    bool isLocked = true;
    while (isLocked)
     try {
      System.IO.File.Move(filename, filename2);
      isLocked = false;
     }
     catch { }
     System.IO.File.Move(filename2, filename);
