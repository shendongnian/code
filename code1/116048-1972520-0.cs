    try
    {
        // Assign a sender, recipient and subject to new mail message
        MailAddress sender =
            new MailAddress("sender@johnnycoder.com", "Sender");
    
        MailAddress recipient =
            new MailAddress("recipient@johnnycoder.com", "Recipient");
    
        MailMessage m = new MailMessage(sender, recipient);
        m.Subject = "Test Message";
    
        // Define the plain text alternate view and add to message
        string plainTextBody =
            "You must use an email client that supports HTML messages";
    
        AlternateView plainTextView =
            AlternateView.CreateAlternateViewFromString(
                plainTextBody, null, MediaTypeNames.Text.Plain);
    
        m.AlternateViews.Add(plainTextView);
    
        // Define the html alternate view with embedded image and
        // add to message. To reference images attached as linked
        // resources from your HTML message body, use "cid:contentID"
        // in the <img> tag...
        string htmlBody =
            "<html><body><h1>Picture</h1><br>" +
            "<img src=\"cid:SampleImage\"></body></html>";
    
        AlternateView htmlView =
            AlternateView.CreateAlternateViewFromString(
                htmlBody, null, MediaTypeNames.Text.Html);
    
        // ...and then define the actual LinkedResource matching the
        // ContentID property as found in the image tag. In this case,
        // the HTML message includes the tag
        // <img src=\"cid:SampleImage\"> and the following
        // LinkedResource.ContentId is set to "SampleImage"
        LinkedResource sampleImage =
            new LinkedResource("sample.jpg",
                MediaTypeNames.Image.Jpeg);
        sampleImage.ContentId = "SampleImage";
    
        htmlView.LinkedResources.Add(sampleImage);
    
        m.AlternateViews.Add(htmlView);
    
        // Finally, configure smtp or alternatively use the
        // system.net mailSettings
        SmtpClient smtp = new SmtpClient
              {
                  Host = "smtp.bigcompany.com",
                  UseDefaultCredentials = false,
                  Credentials =
                      new NetworkCredential("username", "password")
              };
    
        //<system.net>
        //    <mailSettings>
        //        <smtp deliveryMethod="Network">
        //            <network host="smtp.bigcompany.com"
        //              port="25" defaultCredentials="true"/>
        //        </smtp>
        //    </mailSettings>
        //</system.net>
    
        smtp.Send(m);
    }
    catch (ArgumentException)
    {
        throw new
            ArgumentException("Undefined sender and/or recipient.");
    }
    catch (FormatException)
    {
        throw new
            FormatException("Invalid sender and/or recipient.");
    }
    catch (InvalidOperationException)
    {
        throw new
            InvalidOperationException("Undefined SMTP server.");
    }
    catch (SmtpFailedRecipientException)
    {
        throw new SmtpFailedRecipientException(
            "The mail server says that there is no mailbox for recipient");
    }
    catch (SmtpException ex)
    {
        // Invalid hostnames result in a WebException InnerException that
        // provides a more descriptive error, so get the base exception
        Exception inner = ex.GetBaseException();
        throw new SmtpException("Could not send message: " + inner.Message);
    }
