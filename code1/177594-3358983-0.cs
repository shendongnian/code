                    byte[] bytes = new byte[uploader.UploadedFiles[0].InputStream.Length];
                    uploader.UploadedFiles[0].InputStream.Read(bytes, 0, bytes.Length);
    
                    var storedFile = new document();
                    string strFullPath = uploader.UploadedFiles[0].FileName;
                    string strFileName = Path.GetFileName(strFullPath);
    
                    storedFile.document_id = Guid.NewGuid();
                    storedFile.content_type = uploader.UploadedFiles[0].ContentType;
                    storedFile.original_name = strFileName;
                    storedFile.file_data = bytes;
                    storedFile.date_created = DateTime.Now;
                    db.documents.InsertOnSubmit(storedFile);
                    db.SubmitChanges();
