    private void sendMessage(SmsMessage message)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            CookieContainer cookies;
            string url = "http://www.xyzwebsite.com/";
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.AllowAutoRedirect = true;
                request.CookieContainer = new CookieContainer();
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    cookies = request.CookieContainer;
                    
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    String postData = "emailfrom="+credentials.Username+"&npa="+message.DestinationPhoneNumber.Substring(0,3)+"&exchange="+message.DestinationPhoneNumber.Substring(3,3)+"&number="+message.DestinationPhoneNumber.Substring(6)+"&body="+HttpUtility.UrlEncode(message.MessageText)+"&submitted=1&submit=Send";
                    byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(postData);
                    request.ContentLength = data.Length;
                    Stream stream = request.GetRequestStream();
                    stream.Write(data, 0, data.Length);
                    request.CookieContainer = cookies;
                    stream.Close();
                    response = (HttpWebResponse)request.GetResponse();
                    response.Close();
                }
                else
                {
                    Console.WriteLine("Client was unable to connect!");
                }
            }
            catch (System.Exception e)
            {
                throw new SMSDeliveryException("Unable to deliver SMS message because " + e.Message, e);
            }
        }
