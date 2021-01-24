            var message = new MimeMessage ();
            message.From.Add (new MailboxAddress ("Joey", "joey@friends.com"));
            message.To.Add (new MailboxAddress ("Alice", "alice@wonderland.com"));
            message.Subject = "How you doin?";
            var builder = new BodyBuilder ();
            // Set the plain-text version of the message text
            builder.TextBody = @"Hey Alice,... ";
            // We may also want to attach a calendar event for Monica's party...
            builder.Attachments.Add (@"C:\Users\Joey\Documents\party.ics");
            // Now we just need to set the message body and we're done
            message.Body = builder.ToMessageBody ();
