    byte[] filedata = GetMyByteArray();
    string extension = GetTheExtension(); // "pdf", etc
    string filename =System.IO.Path.GetTempFileName() + "." + extension; // Makes something like "C:\Temp\blah.tmp.pdf"
    File.WriteAllBytes(filename, filedata);
    var process = Process.Start(filename);
    // Clean up our temporary file...
    process.Exited += (s,e) => System.IO.File.Delete(filename); 
