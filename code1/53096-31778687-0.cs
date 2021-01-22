       private void GetAttachmentContent(Attachments attachments)
        {
            foreach (Attachment attachment in attachments)
            {
                //microsoft schema to get the attachment content
                string AttachSchema = "http://schemas.microsoft.com/mapi/proptag/0x37010102";
                byte[] filebyte = (byte[])attachment.PropertyAccessor.GetProperty(AttachSchema);
            }
        }
