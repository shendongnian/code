    // this is to add multipel attachments ","
                string[] ToMuliPaths = EmailAttachmentPaths.Split(',');
                foreach (string ToPathId in ToMuliPaths)
                {
                    // only add email if not blank
                    if (ToPathId.Trim() != "")
                        mailMessage.Attachments.Add(new Attachment(ToPathId));
                }// end for loop
