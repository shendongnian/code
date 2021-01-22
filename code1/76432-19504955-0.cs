    //if you want status update only uncomment the below line of code instead
            //var result = tService.SendTweet(new SendTweetOptions { Status = Guid.NewGuid().ToString() });
            Bitmap img = new Bitmap(Server.MapPath("~/test.jpg"));
            if (img != null)
            {
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Seek(0, SeekOrigin.Begin);
                Dictionary<string, Stream> images = new Dictionary<string, Stream>{{"mypicture", ms}};
                //Twitter compares status contents and rejects dublicated status messages. 
                //Therefore in order to create a unique message dynamically, a generic guid has been used
     
                var result = tService.SendTweetWithMedia(new SendTweetWithMediaOptions { Status = Guid.NewGuid().ToString(), Images = images });
                if (result != null && result.Id > 0)
                {
                    Response.Redirect("https://twitter.com");
                }
                else
                {
                    Response.Write("fails to update status");
                }
            }
