    public async Task<ActionResult> FileUpload(HttpPostedFileBase file)
    {
        if (file != null && file.ContentLength > 0)
        {
            var logo = new Logo() { LogoGuid = Guid.NewGuid() };
            var clinica = await GetClinicaAsync();
            var ms = new MemoryStream();
            file.InputStream.CopyTo(ms); // copy HTTP stream to memory stream
            if (IsClinicNonexistent(clinica))
            {
                db.Logos.Add(logo);
                clinica.LogoGuid = logo.LogoGuid;
            }
                
            logo.LogoImage = GetImage(file);
            ms.Position = 0; // make sure the stream is read from beginning
            logo.Thumbnail = GetThumbnail(ms);
            db.SaveChanges();
        }
        return RedirectToAction("Arquivos");
    }
