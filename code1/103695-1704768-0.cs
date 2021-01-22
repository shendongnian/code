    MemberResponse membResp = (MemberResponse )StaticClassName.SerializeIt(request);
    static Object SerializeIt(HttpWebRequest request)
        {
            HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
    
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(MemberResponse));
                return (Object)ser.Deserialize(resp.GetResponseStream());
            }
            catch (Exception e)
            {
                error = e.InnerException.ToString();
                return null;
            }
    
        }
