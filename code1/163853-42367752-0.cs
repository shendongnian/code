			foreach(EmailMessage message in findResults)
			{
				message.Load();
				
				Console.WriteLine(message.Subject.ToString());
                if (message.HasAttachments && message.Attachments[0] is FileAttachment)
                {
                    FileAttachment fileAttachment = message.Attachments[0] as FileAttachment;
                    fileAttachment.Load("C:\\temp\\" + fileAttachment.Name);
                    fileAttachment.Load();
                    Console.WriteLine("FileName: " + fileAttachment.FileName);
                }
			}
