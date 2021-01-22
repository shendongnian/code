    public static class WebHelpers
    {
        public static Encoding encoding = Encoding.UTF8;
        /// <summary>
        /// Post the data as a multipart form
        /// postParameters with a value of type byte[] will be passed in the form as a file, and value of type string will be
        /// passed as a name/value pair.
        /// </summary>
        public static HttpWebResponse MultipartFormDataPost(string postUrl, string userAgent, Dictionary<string, object> postParameters)
        {
            string formDataBoundary = "-----------------------------28947758029299";
            string contentType = "multipart/form-data; boundary=" + formDataBoundary;
            byte[] formData = WebHelpers.GetMultipartFormData(postParameters, formDataBoundary);
            return WebHelpers.PostForm(postUrl, userAgent, contentType, formData);
        }
        /// <summary>
        /// Post a form
        /// </summary>
        private static HttpWebResponse PostForm(string postUrl, string userAgent, string contentType, byte[] formData)
        {
            HttpWebRequest request = WebRequest.Create(postUrl) as HttpWebRequest;
            if (request == null)
            {
                throw new NullReferenceException("request is not a http request");
            }
            // Add these, as we're doing a POST
            request.Method = "POST";
            request.ContentType = contentType;
            request.UserAgent = userAgent;
            request.CookieContainer = new CookieContainer();
            // We need to count how many bytes we're sending. 
            request.ContentLength = formData.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                // Push it out there
                requestStream.Write(formData, 0, formData.Length);
                requestStream.Close();
            }
            return request.GetResponse() as HttpWebResponse;
        }
        /// <summary>
        /// Turn the key and value pairs into a multipart form.
        /// See http://www.ietf.org/rfc/rfc2388.txt for issues about file uploads
        /// </summary>
        private static byte[] GetMultipartFormData(Dictionary<string, object> postParameters, string boundary)
        {
            Stream formDataStream = new System.IO.MemoryStream();
            foreach (var param in postParameters)
            {
                if (param.Value is byte[])
                {
                    byte[] fileData = param.Value as byte[];
                    // Add just the first part of this param, since we will write the file data directly to the Stream
                    string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\";\r\nContent-Type: application/octet-stream\r\n\r\n", boundary, param.Key, param.Key);
                    formDataStream.Write(encoding.GetBytes(header), 0, header.Length);
                    // Write the file data directly to the Stream, rather than serializing it to a string.  This 
                    formDataStream.Write(fileData, 0, fileData.Length);
                }
                else
                {
                    string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}\r\n", boundary, param.Key, param.Value);
                    formDataStream.Write(encoding.GetBytes(postData), 0, postData.Length);
                }
            }
            // Add the end of the request
            string footer = "\r\n--" + boundary + "--\r\n";
            formDataStream.Write(encoding.GetBytes(footer), 0, footer.Length);
            
            // Dump the Stream into a byte[]
            formDataStream.Position = 0;
            byte[] formData = new byte[formDataStream.Length];
            formDataStream.Read(formData, 0, formData.Length);
            formDataStream.Close();
            return formData;
        }
    }
