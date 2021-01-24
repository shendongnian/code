    public void test()
        {
            var postData = "ps_store_id=R6SXStore3";
            postData += "&hpp_key=hpZPXLXZNBLF";
            postData += "&charge_total=2.00";
            postData += "&hpp_preload=";
            postData += "&order_id=";
            var encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(postData);
            var myRequest = (HttpWebRequest)WebRequest.Create("https://esqa.moneris.com/HPPDP/index.php");
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            //This code is to work using SSL
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            //Post the content
            var newStream = myRequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            //Read the response
            var response = myRequest.GetResponse();
            var responseStream = response.GetResponseStream();
            var responseReader = new StreamReader(responseStream);
            var result = responseReader.ReadToEnd();
            responseReader.Close();
            response.Close();
            //Your original code
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(result); //Load the response into the XML
            XmlNodeList parentNode = xmlDoc.GetElementsByTagName("response");
            string xticket;
            string xhpp_id;
            foreach (XmlNode childrenNode in parentNode)
            {
                xticket = childrenNode.SelectSingleNode("ticket").InnerText;
                xhpp_id = childrenNode.SelectSingleNode("hpp_id").InnerText;
            }
        }
        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
