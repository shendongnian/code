            // Send the mail
            client.Send(message);
            //Clean up attachments
            foreach (Attachment attachment in message.Attachments)
            {
                attachment.Dispose();
            }
