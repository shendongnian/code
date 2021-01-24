            RestClient rc = new RestClient($"{URL}{UserAPI}/{user}");
            rc.Authenticator = new HttpBasicAuthenticator(Username, Password);
            RestRequest rr = new RestRequest(Method.PUT);
            rr.AddHeader("OCS-APIRequest", "true");
            rr.AddParameter("key", "email");
            rr.AddParameter("value", email);
            var response = rc.Execute(rr);
