 public static HttpWebResponse requestSecureDocument(HttpWebRequest _request, string _rtcServerURL, string _userName, string _password)
        {
             //FormBasedAuth Step1: Request the resource and clone the request to be used later
            HttpWebRequest _requestClone = WebRequestExtensions.CloneRequest(_request, _request.RequestUri);//(HttpWebRequest)WebRequest.Create(request.RequestUri);
            //store the response in _docResponse variable
            HttpWebResponse _docResponse = (HttpWebResponse)_request.GetResponse();
            //HttpStatusCode.OK indicates that the request succeeded and that the requested information is in the response.
            if (_docResponse.StatusCode == HttpStatusCode.OK)
            {
                //X-com-ibm-team-repository-web-auth-msg header signifies form based authentication is being used
                string _rtcAuthHeader = _docResponse.Headers["X-com-ibm-team-repository-web-auth-msg"];
                if ((_rtcAuthHeader != null) &amp;&amp; _rtcAuthHeader.Equals("authrequired"))
                {
                    _docResponse.GetResponseStream().Flush();
                    _docResponse.Close();
                    //Prepare form for authentication as _rtcAuthHeader = authrequired
                    HttpWebRequest _formPost = (HttpWebRequest)WebRequest.Create(_rtcServerURL + "/j_security_check");
                    _formPost.Method = "POST";
                    _formPost.Timeout = 30000;
                    _formPost.CookieContainer = _request.CookieContainer;
                    _formPost.Accept = "text/xml";
                    _formPost.ContentType = "application/x-www-form-urlencoded";
                    String _authString = "j_username=" + _userName + "&amp;j_password=" + _password; //create authentication string
                    Byte[] _outBuffer = Encoding.UTF8.GetBytes(_authString); //store in byte buffer
                    _formPost.ContentLength = _outBuffer.Length;
                    Stream _str = _formPost.GetRequestStream();
                    _str.Write(_outBuffer, 0, _outBuffer.Length); //update form
                    _str.Close();
                    //FormBasedAuth Step2:submit the login form and get the response from the server
                    HttpWebResponse _formResponse = (HttpWebResponse)_formPost.GetResponse();
                    _rtcAuthHeader = _formResponse.Headers["X-com-ibm-team-repository-web-auth-msg"];
                    //check if authentication has failed
                    if ((_rtcAuthHeader != null) &amp;&amp; _rtcAuthHeader.Equals("authfailed"))
                    {
                         //authentication failed. You can write code to handle the authentication failure.
                        //if (DEBUG) Console.WriteLine("Authentication Failure");
                    }
                    else
                    {
                        //login successful
                        _formResponse.GetResponseStream().Flush();
                        _formResponse.Close();
                        //FormBasedAuth Step3: Resend the request for the protected resource.
                        //if (DEBUG) Console.WriteLine("&gt;&gt; Response " + request.RequestUri);
                        return (HttpWebResponse)_requestClone.GetResponse();
                    }
                }
            }
            //already authenticated return original response_docResponse
            return _docResponse;
        }
