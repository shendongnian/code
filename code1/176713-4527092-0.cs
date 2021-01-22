    protected void Button1_Click(object sender, EventArgs e)
    {
 
        string ct = img.PostedFile.ContentType.ToString();
        string usertoken = Session["usrToken"].ToString();
        string userSecret = Session["usrSecret"].ToString();
        string conkey = Session["ConsumerKey"].ToString();
        string consecret = Session["ConsumerSecret"].ToString();
        string twitkey = Session["twitpickey"].ToString();
        string _m = m.Text; // This takes the Tweet to be posted
         
 
        HttpPostedFile myFile = img.PostedFile;
        string fileName = myFile.FileName.ToString();
 
        int nFileLen = myFile.ContentLength;
        byte[] myData = new byte[nFileLen];
        myFile.InputStream.Read(myData, 0, nFileLen);
 
        TwitPic tw = new TwitPic();
        upres.Text = tw.UploadPhoto(myData, ct, _m, fileName, twitkey, usertoken, userSecret, conkey, consecret).ToString();
        Response.Redirect("twittercb.aspx?oauth_verifier=none");
    }
    public class TwitPic
    {
        private const string TWITPIC_UPLADO_API_URL = "http://api.twitpic.com/2/upload";
        private const string TWITPIC_UPLOAD_AND_POST_API_URL = "http://api.twitpic.com/1/uploadAndPost";
        /// 
        /// Uploads the photo and sends a new Tweet
        /// 
        /// <param name="binaryImageData">The binary image data.
        /// <param name="tweetMessage">The tweet message.
        /// <param name="filename">The filename.
        /// Return true, if the operation was succeded.
        public string UploadPhoto(byte[] binaryImageData, string ContentType, string tweetMessage, string filename, string tpkey, string usrtoken, string usrsecret, string contoken, string consecret)
        {            
            string boundary = Guid.NewGuid().ToString();
            string requestUrl = String.IsNullOrEmpty(tweetMessage) ? TWITPIC_UPLADO_API_URL : TWITPIC_UPLOAD_AND_POST_API_URL;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
            string encoding = "iso-8859-1";
 
            request.PreAuthenticate = true;
            request.AllowWriteStreamBuffering = true;
            request.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
            request.Method = "POST";
 
            string header = string.Format("--{0}", boundary);
            string footer = string.Format("--{0}--", boundary);
 
            StringBuilder contents = new StringBuilder();
            contents.AppendLine(header);
 
            string fileContentType = ContentType;
            string fileHeader = String.Format("Content-Disposition: file; name=\"{0}\"; filename=\"{1}\"", "media", filename);
            string fileData = Encoding.GetEncoding(encoding).GetString(binaryImageData);
 
            contents.AppendLine(fileHeader);
            contents.AppendLine(String.Format("Content-Type: {0}", fileContentType));
            contents.AppendLine();
            contents.AppendLine(fileData);
 
            contents.AppendLine(header);
            contents.AppendLine(String.Format("Content-Disposition: form-data; name=\"{0}\"", "key"));
            contents.AppendLine();
            contents.AppendLine(tpkey);
 
            contents.AppendLine(header);
            contents.AppendLine(String.Format("Content-Disposition: form-data; name=\"{0}\"", "consumer_token"));
            contents.AppendLine();
            contents.AppendLine(contoken);
            contents.AppendLine(header);
            contents.AppendLine(String.Format("Content-Disposition: form-data; name=\"{0}\"", "consumer_secret"));
            contents.AppendLine();
            contents.AppendLine(consecret);
            contents.AppendLine(header);
            contents.AppendLine(String.Format("Content-Disposition: form-data; name=\"{0}\"", "oauth_token"));
            contents.AppendLine();
            contents.AppendLine(usrtoken);
            contents.AppendLine(header);
            contents.AppendLine(String.Format("Content-Disposition: form-data; name=\"{0}\"", "oauth_secret"));
            contents.AppendLine();
            contents.AppendLine(usrsecret);
 
            if (!String.IsNullOrEmpty(tweetMessage))
            {
                contents.AppendLine(header);
                contents.AppendLine(String.Format("Content-Disposition: form-data; name=\"{0}\"", "message"));
                contents.AppendLine();
                contents.AppendLine(tweetMessage);
            }
 
            contents.AppendLine(footer);            
            byte[] bytes = Encoding.GetEncoding(encoding).GetBytes(contents.ToString());            
            request.ContentLength = bytes.Length;
            string mediaurl = "";
            try
            {
                using (Stream requestStream = request.GetRequestStream()) // this is where the bug is due to not being able to seek.
                {        
                    requestStream.Write(bytes, 0, bytes.Length); // No problem the image is posted and tweet is posted
                    requestStream.Close();                       
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) // here I can't get the response
                    { 
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            string result = reader.ReadToEnd();
                            XDocument doc = XDocument.Parse(result); // this shows no root elements and fails here
                            XElement rsp = doc.Element("rsp");
                            string status = rsp.Attribute(XName.Get("status")) != null ? rsp.Attribute(XName.Get("status")).Value : rsp.Attribute(XName.Get("stat")).Value;
                            mediaurl = rsp.Element("mediaurl").Value;
                            return mediaurl;                            
                        } 
                    } 
                                   
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            } 
            return mediaurl;
        }
        
    }
