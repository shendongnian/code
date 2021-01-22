    Stream htmlStream = null;
    Stream imageStream = null;
    Stream fileStream = null;
    try
    {
        // Create the message.
        var from = new MailAddress(FROM_EMAIL, FROM_NAME);
        var to = new MailAddress(TO_EMAIL, TO_NAME);
        var msg = new MailMessage(from, to);
        msg.Subject = SUBJECT;
        msg.SubjectEncoding = Encoding.UTF8;
     
        // Get the HTML from an embedded resource.
        var assembly = Assembly.GetExecutingAssembly();
        htmlStream = assembly.GetManifestResourceStream(HTML_RESOURCE_PATH);
     
        // Perform replacements on the HTML file (if you're using it as a template).
        var reader = new StreamReader(htmlStream);
        var body = reader
            .ReadToEnd()
            .Replace("%TEMPLATE_TOKEN1%", TOKEN1_VALUE)
            .Replace("%TEMPLATE_TOKEN2%", TOKEN2_VALUE); // and so on...
     
        // Create an alternate view and add it to the email.
        var altView = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
        msg.AlternateViews.Add(altView);
     
        // Get the image from an embedded resource. The <img> tag in the HTML is:
        //     <img src="pid:IMAGE.PNG">
        imageStream = assembly.GetManifestResourceStream(IMAGE_RESOURCE_PATH);
        var linkedImage = new LinkedResource(imageStream, "image/png");
        linkedImage.ContentId = "IMAGE.PNG";
        altView.LinkedResources.Add(linkedImage);
     
        // Get the attachment from an embedded resource.
        fileStream = assembly.GetManifestResourceStream(FILE_RESOURCE_PATH);
        var file = new Attachment(fileStream, MediaTypeNames.Application.Pdf);
        file.Name = "FILE.PDF";
        msg.Attachments.Add(file);
     
        // Send the email
        var client = new SmtpClient(...);
        client.Credentials = new NetworkCredential(...);
        client.Send(msg);
    }
    finally
    {
        if (fileStream != null) fileStream.Dispose();
        if (imageStream != null) imageStream.Dispose();
        if (htmlStream != null) htmlStream.Dispose();
    }
