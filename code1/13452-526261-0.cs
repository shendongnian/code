        public static class WebHelpers
        {
            /// <summary>
            /// Post the data as a multipart form
            /// </summary>
            public static HttpWebResponse MultipartFormDataPost(string postUrl, string userAgent, Dictionary<string, string> values, string boundary)
            {
                string formData = WebHelpers.MakeMultipartForm(values, boundary);
                return WebHelpers.PostForm(postUrl, userAgent, "multipart/form-data; boundary=" + boundary, formData);
            }
    
            /// <summary>
            /// Post a form
            /// </summary>
            public static HttpWebResponse PostForm(string postUrl, string userAgent, string contentType, string formData)
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
    
                // We need to count how many bytes we're sending. Post'ed Faked Forms should be name=value&
                byte[] postBytes = Encoding.UTF8.GetBytes(formData);
                request.ContentLength = postBytes.Length;
    
                using (Stream requestStream = request.GetRequestStream())
                {
                    // Push it out there
                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();
                }
    
                return request.GetResponse() as HttpWebResponse;
            }
    
            /// <summary>
            /// Generate random hex digits 
            /// </summary>
            public static string RandomHexDigits(int count)
            {
                Random random = new Random();
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < count; i++)
                {
                    int digit = random.Next(16);
                    result.AppendFormat("{0:x}", digit);
                }
    
                return result.ToString();
            }
    
            /// <summary>
            /// Turn the key and value pairs into a multipart form
            /// </summary>
            private static string MakeMultipartForm(Dictionary<string, string> values, string boundary)
            {
                StringBuilder sb = new StringBuilder();
    
                foreach (var pair in values)
                {
                    sb.AppendFormat("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}\r\n", boundary, pair.Key, pair.Value);
                }
    
                sb.AppendFormat("--{0}--\r\n", boundary);
    
                return sb.ToString();    
            }
        }
    }
