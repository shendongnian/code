      `   
    if( attachementFile!=null)
    {
       Attachment attachment = new Attachment(attachementFile, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = attachment.ContentDisposition;
                disposition.CreationDate = File.GetCreationTime(attachementFile);
                disposition.ModificationDate = File.GetLastWriteTime(attachementFile);
                disposition.ReadDate = File.GetLastAccessTime(attachementFile);
                disposition.FileName = Path.GetFileName(attachementFile);
               disposition.Size = new FileInfo(attachementFile).Length;
                disposition.DispositionType = DispositionTypeNames.Attachment;
                return attachment;
    }`
