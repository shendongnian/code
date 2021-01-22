        public static String UpdateAvatar(String filePath)
        {
            String avatarUrl= "http://twitter.com/account/update_profile_image.xml";
            String file = Path.GetFileName(filePath);
            string imageType;
            switch (Path.GetExtension(file).ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    imageType = "jpg";
                    break;
                case ".gif":
                    imageType = "gif";
                    break;
                case ".png":
                    imageType = "png";
                    break;
                default:
                    throw new ArgumentException(
                        "Can't recognize the extension of the file you're uploading. Please choose either a *.gif, *.jpg, *.jpeg, or *.png file.", filePath);
            }
            string contentBoundaryBase = DateTime.Now.Ticks.ToString("x");
            string beginContentBoundary = string.Format("--{0}\r\n", contentBoundaryBase);
            var contentDisposition = string.Format("Content-Disposition:form-data); name=\"image\"); filename=\"{0}\"\r\nContent-Type: image/{1}\r\n\r\n", file, imageType);
            var endContentBoundary = string.Format("\r\n--{0}--\r\n", contentBoundaryBase);
            var formDataSB = new StringBuilder();
            byte[] fileBytes = null;
            string fileByteString = null;
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[4096];
                var memStr = new MemoryStream();
                memStr.Position = 0;
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    memStr.Write(buffer, 0, bytesRead);
                }
                memStr.Position = 0;
                fileByteString = encoding.GetString(memStr.GetBuffer());
            }
            fileBytes =
                encoding.GetBytes(
                    formDataSB.ToString() +
                    beginContentBoundary +
                    contentDisposition +
                    fileByteString +
                    endContentBoundary);
            var req = (HttpWebRequest)WebRequest.Create(AvatarUpdateURL);
            req.ServicePoint.Expect100Continue = false;
            req.ContentType = "multipart/form-data;boundary=" + contentBoundaryBase;
            req.PreAuthenticate = true;
            req.AllowWriteStreamBuffering = true;
            req.Method = "POST";
            req.ContentLength = fileBytes.Length;
            req.Credentials = new NetworkCredential(Username, Password);
            string responseXml = null;
            using (var reqStream = req.GetRequestStream())
            {
                reqStream.Write(fileBytes, 0, fileBytes.Length);
                reqStream.Flush();
            }
            string httpStatus = string.Empty;
            WebResponse resp = null;
            try
            {
                resp = req.GetResponse();
                httpStatus = resp.Headers["Status"];
                using (var respStream = resp.GetResponseStream())
                using (var respRdr = new StreamReader(respStream))
                {
                    responseXml = respRdr.ReadToEnd();
                }
            }
            catch (WebException wex)
            {
                //do something
            }
            finally
            {
                if (resp != null)
                {
                    resp.Close();
                }
            }
            return responseXml.ToString();
        }
