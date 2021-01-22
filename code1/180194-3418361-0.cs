    // this is for the query string
    char[] temp = new char[1];
    temp[0] = '?';
    
    // create the query string for post/get types
    Uri uri = _type == PostType.Post ? new Uri( url ) : new Uri( ( url + "?" + postData ).TrimEnd( temp ) );
    
    // create the request
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create( uri );
    
    request.Accept = _accept;
    request.ContentType = _contentType;
    request.Method = _type == PostType.Post ? "POST" : "GET";
    request.CookieContainer = _cookieContainer;
    request.Referer = _referer;
    request.AllowAutoRedirect = _allowRedirect;
    request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.1.3) Gecko/20090824 Firefox/3.5.3";
    
    // set the timeout to a big value like 2 minutes
    request.Timeout = 120000;
    
    // set our credentials
    request.Credentials = CredentialCache.DefaultCredentials;
    
    // if we have a proxy set its creds as well
    if( request.Proxy != null )
    {
       request.Proxy.Credentials = CredentialCache.DefaultCredentials;
    }
    
    
    // append post items if we need to
    if( !String.IsNullOrEmpty( _body ) )
    {
      using( StreamWriter sw = new StreamWriter( request.GetRequestStream(), Encoding.ASCII ) )
      {
         sw.Write( _body );
      }
    }
    
    if( _type == PostType.Post &&
         String.IsNullOrEmpty( _body ) )
    {
      using( Stream writeStream = request.GetRequestStream() )
      {
          UTF8Encoding encoding = new UTF8Encoding();
          byte[] bytes = encoding.GetBytes( postData );
    
          writeStream.Write( bytes, 0, bytes.Length );
        }
    }
    
    if( _headers.Count > 0 )
    {
      request.Headers.Add( _headers );
    }//end if
    
    // we want to keep this open for a bit
    using( HttpWebResponse response = (HttpWebResponse)request.GetResponse() )
    {
        // TODO: do something with the response
    }//end using
