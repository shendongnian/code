    var stream = new MemoryStream();
                    doc.WriteToStream(stream);
                    stream.Position = 0;
    
                    var contentType = new ContentType(MediaTypeNames.Application.Pdf)
                    {
                        Name ="withoutfilename.pdf";
                    };
                    var attachment = new Attachment(stream, contentType);
    mailMsg.Attachments.Add(attachment);
