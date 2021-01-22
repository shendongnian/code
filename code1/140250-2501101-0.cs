    // get the PDF in byte form from the system
    var bytes = GetFileBytes("Some identifier");
    // get a valid temporary file name and change the extension to PDF
    var tempFileName = Path.ChangeExtension(Path.GetTempFileName(), "PDF");
    // write the bytes of the PDF to the temp file
    File.WriteAllBytes(tempFileName, bytes);
    // Ask the system to handle opening of this file
    Process.Start(tempFileName);
