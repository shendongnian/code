     FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
            "userName",
            DateTime.Now,
            DateTime.Now.AddMinutes(30), // value of time out property
            false, // Value of IsPersistent property
            String.Empty,
            FormsAuthentication.FormsCookiePath);
