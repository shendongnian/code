    public static string PostXMLDataCS()
        {
            bool debugging = false;
            try
            {
                
                string iConnectAuth = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
      "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:tem=\"http://tempuri.org/\">" +
                "<soapenv:Header/>" +
           "<soapenv:Body>" +
            "<tem:Authenticate>" +
             "<!--Optional:-->" +
              "<tem:TenantID>TenantID</tem:TenantID>" +
                   "<!--Optional:-->" +
                    "<tem:Username>Username</tem:Username>" +
                         "<!--Optional:-->" +
                          "<tem:Password>password</tem:Password>" +
                               "</tem:Authenticate>" +
                                "</soapenv:Body>" +
                                 "</soapenv:Envelope>";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.example.com/services/ByDesign/Inventory.svc");
                byte[] bytes;
                bytes = System.Text.Encoding.ASCII.GetBytes(iConnectAuth);
                request.ContentType = "text/xml; charset=utf-8";
                request.Accept = "gzip,deflate";
                request.ContentLength = bytes.Length;
                request.Method = "POST";
                request.Headers.Add("SOAPAction", "http://tempuri.org/IInventory/Authenticate");
                request.KeepAlive = true;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                HttpWebResponse response;
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();
                    response.Close();
                    //MessageBox.Show(responseStr);
                    return responseStr;
                }
            }
            catch (Exception e)
            {
                if (debugging == true)
                {
                    MessageBox.Show("There was a problem authenticating for the check inventory with iConnect. Error: " + e);
                }
                string messageSubject = "There was a problem authenticating for the check inventory with iConnect.";
                string messageBody = "There was a problem authenticating for the check inventory with iConnect. Error: ";
                string kiboSendEmail = string.Empty;
                SendEmail sendEmail = new SendEmail();
                return kiboSendEmail = sendEmail.SendEmailCS(messageSubject, messageBody, e);
                
            }
            return null;
        }
