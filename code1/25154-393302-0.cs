    //In LoginForm.cs
    if (((HttpWebResponse)request.GetResponse()).StatusCode.ToString().Equals("Found"))
                {
                        nextUrl = ((HttpWebResponse)request.GetResponse()).Headers.Get(4);
                        StringBuilder FullUrl = new StringBuilder(this.server_address);
                        FullUrl.Append(nextUrl);
                        this.setSecretURL(FullUrl.ToString());
    
                        setLoginSuccess(true);
                        // now we can send out cookie along with a request for the protected page
                        request = WebRequest.Create(SECRET_PAGE_URL) as HttpWebRequest;
                        request.CookieContainer = cookies;
                        StreamReader responseReader = new StreamReader(request.GetResponse().GetResponseStream());
    
                        // and read the response
                        result = responseReader.ReadToEnd();
                        responseReader.Close();
    
         } else 
         {
              setLoginSuccess(false);                   
         }
