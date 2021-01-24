    String responseString = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://myapiURL");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/values").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    responseString = Regex.Unescape(responseString).Replace("\"","");//Because the response is something like \\"Domaine\\\\Username\"\
                }
                else
                {
                    return View();//server cannot be found or Windows authentication fail => form Login
                }
            }
            String username = "";
            String domain = "";
            if (responseString != "" && responseString.Contains("\\"))
            {
                domain = responseString.Split('\\')[0];
                username = responseString.Split("\\")[1];
                if(domain !="MYDOMAIN")
                {
                    return View();//Not in the correct domain => form Login
                }
            }
            else
            {
                return View();//Not the correct response => form Login
            }
            UserPrincipal user = UserPrincipal.FindByIdentity(new PrincipalContext(ContextType.Domain), username);
            
            if (null != user)
            {
                CustomAutomaticLogin(user)//All seems ok, try to log the user with custom login with AD informations
            }
            else
            {
               return View()//Not in AD => form login
            }
    }
