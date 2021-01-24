     private static string _strSISApiUrl = "YourAPIURL";
    
      public static string GetUserAuthenticationToken(string strUserID, string strPwd)
    
      {
        #if(SISAVILABLE)
    
        List<KeyValuePair<string,string>> objKeyValuePair= new List<KeyValuePair<string,string>>();
                    objKeyValuePair.Add(new KeyValuePair<string,string>("username",strUserID));
                    objKeyValuePair.Add(new KeyValuePair<string,string>("password",strPwd));
                    string jSONResult = RestHttpClient.HttpPost(_strSISApiUrl + "login", objKeyValuePair);
                    return jSONResult;
                #else
                    return "{auth_token:'your api token'}";
                #endif
            }
