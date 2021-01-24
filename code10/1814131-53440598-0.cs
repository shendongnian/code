	List<MailMessage> list = new List<MailMessage>();
	IEnumerable<Attachment> pdfAttachmentsCollection = 
        list.SelectMany(message => 
			message.Attachments
				.Where(attachment => attachment.Name.EndsWith(".pdf")));
