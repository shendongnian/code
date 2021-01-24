     public FileContentResult  ViewFileByFileId (int id)
        {
            DoctorCredentialDocsModel DoctorCredential = new DoctorCredentialDocsModel();
            DoctorCredential = _doctorService.GetDoctorCredentialDetails(id);
            string AttachPath = ConfigPath.DoctorCredentialsAttachmentPath;
            string strFileFullPath = Path.Combine(AttachPath, DoctorCredential.AttachedFile);
    
            string contentType = MimeTypes.GetMimeType(strFileFullPath);
            if (!strFileFullPath.Contains("..\\"))
            {
                byte[] filedata = System.IO.File.ReadAllBytes(strFileFullPath);
                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = DoctorCredential.FileName,
                    Inline = false,
                };
                Request.HttpContext.Response.Headers.Add("Content-Disposition", cd.ToString());
                return File(filedata, contentType);
            }
            else
            {
                return new NotFoundResult();
    
            }
        }
