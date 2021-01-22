    string fileName = Path.Combine(Path.GetTempPath(),FileUploadControl.FileName);
    using (FileStream fs = File.Open(fileName, FileMode.Create, FileAccess.Write))
    {
        fs.Write(FileUploadControl.FileBytes, 0, FileUploadControl.FileBytes.Length);
    }
    
    Attachment attachment = new Attachment(fileName);
    msg.Attachments.Add(attachment);
