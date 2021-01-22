    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1, // Ticket version
                    name, // Username associated with ticket
                    DateTime.Now, // Date/time issued
                    DateTime.Now.AddMonths(1), // Date/time to expire
                    true, // "true" for a persistent user cookie
                    DateTime.Now.ToUniversalTime(), // last time the users was checked
                    FormsAuthentication.FormsCookiePath);// Path cookie valid for
            // Encrypt the cookie using the machine key for secure transport
            string hash = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(
                FormsAuthentication.FormsCookieName, // Name of auth cookie
                hash); // Hashed ticket
            cookie.HttpOnly = true;
            // Set the cookie's expiration time to the tickets expiration time
            if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
            //cookie.Secure = FormsAuthentication.RequireSSL;
            Response.Cookies.Add(cookie);
