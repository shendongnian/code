 // Embeds image to properly show in Email. Image element to show in html will not work in Email body. 
                        // https://stackoverflow.com/questions/39785600/iterate-through-an-html-string-to-find-all-img-tags-and-replace-the-src-attribut
                        // XmlAgilityPack gets used here to parse html string. 
                        List<LinkedResource> linkedResources = new List<LinkedResource>(); 
                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        int increment = 0; 
                        doc.LoadHtml(tempMsg);
                        doc.DocumentNode.Descendants("img").Where(z =>
                            {
                                string src = z.GetAttributeValue("src", null) ?? "";
                                return !string.IsNullOrEmpty(src) && src.StartsWith("data:image");
                            })
                            .ToList()
                            .ForEach(x =>
                            {
                                string currentSrcValue = x.GetAttributeValue("src", null);
                                currentSrcValue = currentSrcValue.Split(',')[1];    //Base64 part of string
                                byte[] imageData = Convert.FromBase64String(currentSrcValue);
                                string id = Guid.NewGuid().ToString();
                                increment++;
                                LinkedResource inlineImage = new LinkedResource(new MemoryStream(imageData), System.Net.Mime.MediaTypeNames.Image.Jpeg);
                                inlineImage.ContentType.Name = "img " + increment; 
                                inlineImage.ContentId = id;
                                inlineImage.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                                x.SetAttributeValue("src", "cid:" + inlineImage.ContentId);
                                linkedResources.Add(inlineImage);
                            });
                        // Append multiple images from template to email message.
                        // https://stackoverflow.com/questions/7048758/how-to-embed-multiple-images-in-email-body-using-net
                        // Write html to message.body 
                        AlternateView altView = AlternateView.CreateAlternateViewFromString(doc.DocumentNode.OuterHtml, null, "text/html");
                        linkedResources.ForEach(x=>altView.LinkedResources.Add(x));
                        message.AlternateViews.Add(altView);
                        
                        String[] attachments = txtAttachFiles.Text.Split(';');
                        foreach (String filename in attachments)
                        {
                            if (File.Exists(filename))
                            {
                                Attachment attachment = new Attachment(filename);
                                message.Attachments.Add(attachment);
                            }
                        }
                        
                        // loop is set to 1 in the app.config file so technically this for loop is not needed, but will keep this loop just in case. 
                        for (int loop = 0; loop < Convert.ToInt32(ConfigurationManager.AppSettings["loop"]); loop++)
                        {
                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = ConfigurationManager.AppSettings["mailHost"];
                            smtp.Port = Int32.Parse(ConfigurationManager.AppSettings["mailPort"]);
                            smtp.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["mailDefaultCredentials"]);
                            smtp.Send(message);
                        }
                    }
