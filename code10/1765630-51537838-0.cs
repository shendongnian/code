    //This  is the code get byte stream from the URL    
    WebClient myClient = new WebClient();
            byte[] bytes = myClient.DownloadData("http://www.examle.com/mypdf.pdf");
            System.IO.MemoryStream webPdf = new MemoryStream(bytes);
    //To Create the Attachment for sending mail.
    System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
                Attachment attach = new Attachment(webPdf, ct);
                attach.ContentDisposition.FileName = "myFile.pdf";
                var smtp = new SmtpClient
                {
                    Host = "email.thyrocare.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
     //Here webpdf is the bytestream which is going to attach in the mail
                    message.Attachments.Add(new Attachment(webPdf, "sample.pdf"));
                    smtp.Send(message);
                }
                webPdf.Dispose();
                webPdf.Close();
