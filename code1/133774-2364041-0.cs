        private string SendData(string method, string directory, string data)
        {
            string page = string.Format("http://{0}/{1}", DeviceAddress, directory);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(page);
            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = method;
            // turn our request string into a byte stream
            byte[] postBytes;
            
            if(data != null)
            {
                postBytes = Encoding.UTF8.GetBytes(data);
            }
            else
            {
                postBytes = new byte[0];
            }
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postBytes.Length;
            
            Stream requestStream = request.GetRequestStream();
            // now send it
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            return GetResponseData(response);
        }
