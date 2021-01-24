            FileInfoCard card = new FileInfoCard()
            {
                FileType = "docx",
                UniqueId = Guid.NewGuid().ToString() // unique id.
            };
            Attachment att = card.ToAttachment();
            att.ContentUrl = contentUrl;
            att.Name = name;
