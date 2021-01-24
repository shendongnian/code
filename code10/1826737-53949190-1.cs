    MimeMessage message;
    
    using (var stream = new MemoryStream (email.MimeContent.Content, email.MimeContent.Length))
        message = MimeMessage.Load (stream);
    
    var pkcs7 = message.BodyParts.OfType<ApplicationPkcs7Mime> ().FirstOrDefault ();
    if (pkcs7 != null) {
        using (var ctx = new TemporarySecureMimeContext ()) {
            using (var stream = File.OpenRead (ConfigurationManager.AppSettings["certLocation"]))
                ctx.Import (stream, ConfigurationManager.AppSettings["certPassword"]);
    
            // decrypt the MIME part (result will be another MIME entity)
            var decrypted = pkcs7.Decrypt (ctx);
            // The decrypted MIME entity could be a message/rfc822 part (which
            // contains a message), a multipart (such as multipart/mixed) which
            // contains a list of subparts, each with their own content... or it
            // could be a regular MIME part which just has content. Assuming it
            // is just a regular MIME part:
            if (decrypted is MimePart) {
                var part = (MimePart) decrypted;
                using (var stream = File.Create ("decrypted-content.dat"))
                    part.Content.DecodeTo (stream);
            }
        }
    }
