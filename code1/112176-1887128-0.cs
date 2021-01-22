    CookieContainer cookies = new CookieContainer();
    HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(someSite);
    getRequest.CookieContainer = cookies;
    getRequest.Method = "GET";
    HttpWebResponse form = (HttpWebResponse)getRequest.GetResponse();
    using (StreamReader response = 
       new StreamReader(form.GetResponseStream(), Encoding.UTF8))
    {
        formPage = response.ReadToEnd();
    }
