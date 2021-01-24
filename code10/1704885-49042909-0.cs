    bool authentic = false;
    using (var context = new PrincipalContext(ContextType.Domain, "172.16.0.181:390", username  , password))
            {
       
                if (context.ValidateCredentials(username, password) == true)
                {
                    authentic = true;
                }
    }
