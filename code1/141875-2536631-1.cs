    string addr = textBox1.Text;
            string result = "";
            Uri uri = WebRequest.DefaultWebProxy.GetProxy(new Uri(addr));
            WebProxy myProxy = new WebProxy("ems28.your-freedom.de", 443);
            myProxy.Credentials = new NetworkCredential("user", "pass");
            myProxy.BypassProxyOnLocal=true;
            
            try{
            WebRequest req = WebRequest.Create(addr);
            req.Proxy = myProxy;
            HttpWebResponse response = (HttpWebResponse)req.GetResponse(); System.IO.Stream stream = response.GetResponseStream();
            System.Text.Encoding ec = System.Text.Encoding.GetEncoding("utf-8");
            System.IO.StreamReader reader = new System.IO.StreamReader(stream, ec);
            char [] chars = new Char[256];
            int count = reader.Read(chars, 0, 256);
            while(count > 0)
            {
            string str = new String(chars, 0, 256);
            result = result + str;
            count = reader.Read(chars, 0, 256);
            }
            response.Close();
            stream.Close();
            reader.Close();
            }
            catch(Exception exp)
            {
            string str = exp.Message;
            }
            MessageBox.Show(result);
            webBrowser1.Url = uri;
            webBrowser1.GoForward();
