        public string ExtractAlternateView()
        {
            var message = new System.Net.Mail.MailMessage();
            message.Body = "This is the TEXT version";
            //Add textBody as an AlternateView
            message.AlternateViews.Add(
                System.Net.Mail.AlternateView.CreateAlternateViewFromString(
                    "This is the HTML version",
                    new System.Net.Mime.ContentType("text/html")
                )
            );
            var dataStream = message.AlternateViews[0].ContentStream;
            byte[] byteBuffer = new byte[dataStream.Length];
            return System.Text.Encoding.ASCII.GetString(byteBuffer, 0, dataStream.Read(byteBuffer, 0, byteBuffer.Length));
        }
