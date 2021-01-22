    private void sendMessage(JaxtrSmsMessage message)
    {
        HttpWebRequest request;
        HttpWebResponse response;
        CookieContainer cookies;
        string url = "http://www.jaxtr.com/user/login.jsp";
    
        try
        {
            request = (HttpWebRequest)WebRequest.Create(url);
            request.AllowAutoRedirect = true;
            request.CookieContainer = new CookieContainer();
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                StringBuilder sb = new StringBuilder();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                while (!reader.EndOfStream)
                {
                    sb.AppendLine(reader.ReadLine());
                }
    
                //Get the hidden value out of the form.                
                String fp = Regex.Match(sb.ToString(), "\"__fp\"\\svalue=\"(([A-Za-z0-9+/=]){4}){1,19}\"", RegexOptions.None).Value;
                fp = fp.Substring(14);
                fp = fp.Replace("\"", String.Empty);
    
    
                cookies = request.CookieContainer;
                //response.Close();
                String requestString = "http://www.jaxtr.com/user/Login.action?tzOffset=6&navigateURL=&refPage=&jaxtrId=" + HttpUtility.UrlEncode(credentials.Username) + "&password=" + HttpUtility.UrlEncode(credentials.Password) + "&Login=Login&_sourcePage=%2Flogin.jsp&__fp="+HttpUtility.UrlEncode(fp);
                request = (HttpWebRequest)WebRequest.Create(requestString);
                request.CookieContainer = cookies; //added by myself
    
                response = (HttpWebResponse)request.GetResponse();
                Console.WriteLine("Response from login:" + response.StatusCode);
    
                String messageText = (message.TruncateMessage && message.MessageText.Length > JaxtrSmsMessage.MAX_MESSAGE_LENGTH ? message.MessageText.Substring(JaxtrSmsMessage.MAX_MESSAGE_LENGTH) : message.MessageText);
    
                String messageURL = "http://www.jaxtr.com/user/sendsms?CountryName=" + HttpUtility.UrlEncode(message.CountryName) + "&phone=" + HttpUtility.UrlEncode(message.DestinationPhoneNumber) + "&message=" + HttpUtility.UrlEncode(messageText) + "&bySMS=" + HttpUtility.UrlEncode(message.BySMS.ToString().ToLower());
    
                request = (HttpWebRequest)WebRequest.Create(messageURL);
                request.CookieContainer = cookies;
                response = (HttpWebResponse)request.GetResponse();
    
                Console.WriteLine("Response from send SMS command=" + response.StatusCode);
    
                StringBuilder output = new StringBuilder();
    
                using (Stream s = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(s);
                    while (!sr.EndOfStream)
                    {
                        output.AppendLine(sr.ReadLine());
                    }
                }
                response.Close();
            }
            else
            {
                Console.WriteLine("Client was unable to connect!");
            }
        }
        catch (System.Exception e)
        {
            throw new SMSDeliveryException("Unable to deliver SMS message because "+e.Message, e);
        }
    }
