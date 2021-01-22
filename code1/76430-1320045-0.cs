        static void PostTweet(string username, string password, string tweet)
        {
             // Create a webclient with the twitter account credentials, which will be used to set the HTTP header for basic authentication
             WebClient client = new WebClient { Credentials = new NetworkCredential { UserName = username, Password = password } };
             // Don't wait to receive a 100 Continue HTTP response from the server before sending out the message body
             ServicePointManager.Expect100Continue = false;
        
             // Construct the message body
             byte[] messageBody = Encoding.ASCII.GetBytes("status=" + tweet);
        
             // Send the HTTP headers and message body (a.k.a. Post the data)
             client.UploadData("http://twitter.com/statuses/update.xml", messageBody);
        }
