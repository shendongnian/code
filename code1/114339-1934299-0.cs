    int loop1;
    HttpFileCollection files;
    InputStream input;
    
    files = Request.Files;
    arr1 = Files.AllKeys;
    
    for (loop1 = 0; loop1 < arr1.Length; loop1++) {
      input = files[loop1].InputStream;
      // Use input to access the file content.
    }
