    public ActionResult downloadF(int? id) {
        var attach      = db.details.First(a => a.id == id);
        var fileattach  = new FileContentResult(attach.foto.ToArray(), "application/octet-stream");
        var fileattach2 = new FileContentResult(attach.passport.ToArray(), "application/octet-stream");
        var fileattach3 = new FileContentResult(attach.degree.ToArray(), "application/octet-stream");
    
        using (var memoryStream = new MemoryStream()) {
            using (var ziparchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true)) {
                
                    var fotoEntry = ziparchive.CreateEntry("foto", CompressionLevel.Optimal);
                    using (var fotoStream = fotoEntry .Open())
                    using (var fotoIn = new MemoryStream(attach.foto.ToArray()))
                    {
                        fotoIn.CopyTo(fotoStream);
                    }
 
                    var passportEntry = ziparchive.CreateEntry("passport", CompressionLevel.Optimal);
                    using (var passportStream = passportEntry .Open())
                    using (var passportIn = new MemoryStream(attach.passport.ToArray()))
                    {
                        passportIn .CopyTo(passportStream );
                    }
                    var degreeEntry = ziparchive.CreateEntry("degree", CompressionLevel.Optimal);
                    using (var degreeStream = degreeEntry .Open())
                    using (var degreeIn= new MemoryStream(attach.degree.ToArray()))
                    {
                        degreeIn.CopyTo(degreeStream );
                     }
            }
    
            return File(memoryStream.ToArray(), "application/zip", "Attachments.zip");
        }
 
