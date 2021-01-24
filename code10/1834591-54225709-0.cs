`
private void AddMessageAsAttachment(Microsoft.Office.Interop.Outlook.MailItem 
                     mailContainer,Microsoft.Office.Interop.Outlook.MailItem mailToAttach)
        {
            Microsoft.Office.Interop.Outlook.Attachments attachments = null;
            Microsoft.Office.Interop.Outlook.Attachment attachment = null;
            try
            {
                attachments = mailContainer.Attachments;
                attachment = attachments.Add(mailToAttach,
                   Microsoft.Office.Interop.Outlook.OlAttachmentType.olEmbeddeditem, 1, "The attached e-mail");
                mailContainer.Save();
            }
            catch (Exception ex)
            {
                    Console.WriteLine(ex.Message);
            }
            finally
            {
                if (attachment != null) Marshal.ReleaseComObject(attachment);
                if (attachments != null) Marshal.ReleaseComObject(attachments);
            }
        }
`
reference : <https://www.add-in-express.com/creating-addins-blog/2011/08/12/how-to-add-existing-e-mail-message-as-attachment/>
