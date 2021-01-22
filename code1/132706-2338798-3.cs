    void CreatePreApplication() {
        Pre_Application p = new PreApplication();
        p.FileName = Path.GetFileName(ctrFile.PostedFile.FileName);
        p.FileType = ctrFile.PostedFile.ContentType;
        p.FileSize = ctrFile.PostedFile.ContentLength;
        byte[] fileContent = new byte[ctrFile.PostedFile.ContentLength];
        ctrFile.PostedFile.InputStream.Read(fileContent, 0, ctrFile.PostedFile.ContentLength);
        p.FileContent = fileContent;
        //do the insert after you have assigned all the variables
        p.DoInsert();
    }
