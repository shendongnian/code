    using (var decryptedStream = new MemoryStream (envelopedCms.ContentInfo.Content)) {
        var entity = MimeEntity.Load (decryptedStream);
        
        if (entity is ApplicationPkcs7Mime) {
            // Note: no need to create a new ApplicationPkcs7Mime part, just cast it!
            var p7m = (ApplicationPkcs7Mime) entity;
            using (var ctx = new TemporarySecureMimeContext ()) {
                // Import the X509Certificate2 into the S/MIME context
                var cert = Org.BouncyCastle.Security.DotNetUtilities.FromX509Certificate (certificate);
                ctx.Import (cert);
                if (p7m.SecureMimeType == SecureMimeType.SignedData) {
                    // Verify the content *and* extract the original content from the binary envelope
                    MimeEntity extracted;
                    var signatures = p7m.Verify (ctx, out extracted);
                    // Save the Excel content to disk
                    using (var stream = File.Create ("excel.xls")) {
                        var part = extracted as MimePart;
                        part.Content.DecodeTo (stream);
                    }
                }
            }
        }
    }
