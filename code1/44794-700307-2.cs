            HttpRequest original = context.Request;
            HttpWebRequest newRequest = (HttpWebRequest)WebRequest.Create(newUrl);
            newRequest .ContentType = original.ContentType;
            newRequest .Method = original.HttpMethod;
            newRequest .UserAgent = original.UserAgent;
            
            byte[] originalStream = ReadToByteArray(original.InputStream, 1024);
            Stream reqStream = newRequest .GetRequestStream();
            reqStream.Write(originalStream, 0, originalStream.Length);
            reqStream.Close();
            newRequest .GetResponse();
