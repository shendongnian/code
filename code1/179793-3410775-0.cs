    string fileName = Path.Combine(Path.GetTempPath(),FileUploadControl.FileName);
    using (FileStream fs = File.Open(fileName, FileMode.Create, FileAccess.Write, FileShare.Read))
    {
        byte[] buffer = new byte[1024];
        int bytesRead; while ((bytesRead = FileUploadControl.PostedFile.InputStream.Read(buffer, 0, buffer.Length)) > 0) 
        {
            fs.Write(buffer, 0, bytesRead);
        }
    }
    
    Attachment attachment = new Attachment(fileName);
    msg.Attachments.Add(attachment);
