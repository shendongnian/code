            // Read file data
            FileStream fs = new FileStream("c:\\people.doc", FileMode.Open, FileAccess.Read);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
            fs.Close();
            // Generate post objects
            Dictionary<string, object> postParameters = new Dictionary<string, object>();
            postParameters.Add("filename", "People.doc");
            postParameters.Add("fileformat", "doc");
            postParameters.Add("file", data);
            // Create request and receive response
            string postURL = "http://stackoverflow.com";
            string userAgent = "Someone";
            HttpWebResponse webResponse = WebHelpers.MultipartFormDataPost(postURL, userAgent, postParameters);
            // Process response
            StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
            string fullResponse = responseReader.ReadToEnd();
            webResponse.Close();
            Response.Write(fullResponse);
