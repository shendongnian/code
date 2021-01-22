            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD";
            string code = "";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                code = response.StatusCode.ToString();
            }
            catch 
            {
            }
            
            return code; // if "OK" blob exists
