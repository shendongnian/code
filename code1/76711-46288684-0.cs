            string startupPath = AppDomain.CurrentDomain.RelativeSearchPath;
            string path = Path.Combine(startupPath, "HtmlTemplates", "NotifyTemplate.html");
            string body = File.ReadAllText(path);
            //General tags replacement.
            body = body.Replace("[NOMBRE_COMPLETO]", request.ToName);
            body = body.Replace("[ASUNTO_MENSAJE]", request.Subject);
            //Image List Used to replace into the template.
            string[] imagesList = { "h1.gif", "left.gif", "right.gif", "tw.gif", "fb.gif" };
            //Here we create link resources one for each image. 
            //Also the MIME type is obtained from the image name and not hardcoded.
            List<LinkedResource> imgResourceList = new List<LinkedResource>();
            foreach (var img in imagesList)
            {
                string imagePath = Path.Combine(startupPath, "Images", img);
                var image = new LinkedResource(imagePath, "image/" + img.Split('.')[1]);
                image.ContentId = Guid.NewGuid().ToString();
                image.ContentType.Name = img;
                imgResourceList.Add(image);
                body = body.Replace("{" + Array.IndexOf(imagesList, img) + "}", image.ContentId);
            }
            //Altern view for managing images and html text is created.
            var view = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            //You need to add one by one each link resource to the created view
            foreach (var imgResorce in imgResourceList)
            {
                view.LinkedResources.Add(imgResorce);
            }
            ThreadPool.QueueUserWorkItem(o =>
            {
                using (SmtpClient smtpClient = new SmtpClient(servidor, Puerto))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Timeout = 50000;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new System.Net.NetworkCredential()
                    {
                        UserName = UMail,
                        Password = password
                    };
                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.IsBodyHtml = true;
                        mailMessage.From = new MailAddress(UMail);
                        mailMessage.To.Add(request.ToEmail);
                        mailMessage.Subject = "[NAPNYL] " + request.Subject;
                        mailMessage.AlternateViews.Add(view);
                        smtpClient.Send(mailMessage);
                    }
                }
            });
