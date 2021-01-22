    protected void sendHTMLEmail(object s, EventArgs e)
	{
		/* adapted from http://stackoverflow.com/questions/1113345/sending-mail-along-with-embedded-image-using-asp-net 
		   and http://stackoverflow.com/questions/886728/generating-html-email-body-in-c-sharp */
		string myTestReceivingEmail = "yourEmail@address.com"; // your Email address for testing or the person who you are sending the text to.
		string subject = "This is the subject line";
		string firstName = "John";
		string mobileNo = "07711 111111";
		// Create the message.
		var from = new MailAddress("emailFrom@address.co.uk", "displayed from Name");
		var to = new MailAddress(myTestReceivingEmail, "person emailing to's displayed Name");
		var mail = new MailMessage(from, to);
		mail.Subject = subject;
		// Perform replacements on the HTML file (which you're using as a template).
		var reader = new StreamReader(@"c:\Temp\HTMLfile.htm");
		string body = reader.ReadToEnd().Replace("%TEMPLATE_TOKEN1%", firstName).Replace("%TEMPLATE_TOKEN2%", mobileNo); // and so on as needed...
		// replaced this line with imported reader so can use a templete .... 
		//string html = body; //"<html><body>Text here <br/>- picture here <br /><br /><img src=""cid:SACP_logo_sml.jpg""></body></html>";
		// Create an alternate view and add it to the email. Can implement an if statement to decide which view to add //
		AlternateView altView = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
		// Logo 1 //
		string imageSource = (Server.MapPath("") + "\\logo_sml.jpg");
		LinkedResource PictureRes = new LinkedResource(imageSource, MediaTypeNames.Image.Jpeg);
		PictureRes.ContentId = "logo_sml.jpg";
		altView.LinkedResources.Add(PictureRes);
		// Logo 2 //
		string imageSource2 = (Server.MapPath("") + "\\booking_btn.jpg");
		LinkedResource PictureRes2 = new LinkedResource(imageSource2, MediaTypeNames.Image.Jpeg);
		PictureRes2.ContentId = "booking_btn.jpg";
		altView.LinkedResources.Add(PictureRes2);
		mail.AlternateViews.Add(altView);
		// Send the email (using Web.Config file to store email Network link, etc.)
		SmtpClient mySmtpClient = new SmtpClient();
		mySmtpClient.Send(mail);
	}
