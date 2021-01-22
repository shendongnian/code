    using (TempFileStream t as new TempFileStream())
    {
       WriteDataToTempFile(t);
       t.Seek(0, SeekOrigin.Begin);
       ReadDataFromTempFile(t);
    }
