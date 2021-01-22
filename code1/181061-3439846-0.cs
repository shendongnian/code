private string DownlodHTMLPage(Uri url)
        {
            WebResponse response = null;
            Stream stream = null;
            StreamReader sr = null;
            try
            {
                HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(url);
                //sometimes it doesn't work if user agent is not set
                hwr.UserAgent = "Opera/9.80 (Windows NT 5.1; U; pl) Presto/2.2.15 Version/10.10";
                response = hwr.GetResponse();
                stream = response.GetResponseStream();
                //check if content type of page is text/xxx. you can add statement for XHTML files
                if (!response.ContentType.ToLower().StartsWith("text/"))
                {
                    return null;
                }
                string buffer = "", line;
                //get the stream reader
                sr = new StreamReader(stream);
                //download HTML to buffer
                while ((line = sr.ReadLine()) != null)
                {
                    buffer += line + "\r\n"; //line with new line markers
                }
                return buffer;
            }
            catch (WebException e)
            {
                System.Console.WriteLine("Can't download from " + url + " 'casue " + e);
                return null;
            }
            catch (IOException e)
            {
                System.Console.WriteLine("Can't download from " + url + " 'cause " + e);
                return null;
            }
            finally
            {
                if (sr != null)
                    sr.Close();
                if (stream != null)
                    stream.Close();
                if (response != null)
                    response.Close();
            }
        }
