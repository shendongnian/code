            response = (HttpWebResponse)request.GetResponse();
            string Charset = response.CharacterSet;
            Encoding encoding = Encoding.GetEncoding(Charset);
           
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response_stream = new StreamReader(response.GetResponseStream(), encoding);
                html = response_stream.ReadToEnd();
            }
