     public void SetAuthenticationCookie(LoginView loginModel)
        {
          if (!loginModel.RememberMe)
          {
            FormsAuthentication.SetAuthCookie(loginModel.Email, false);
            return;
          }
          const int timeout = 2880; // Timeout is in minutes, 525600 = 365 days; 1 day = 1440.
          var ticket = new FormsAuthenticationTicket(loginModel.Email, loginModel.RememberMe, timeout);
          //ticket.
          string encrypted = FormsAuthentication.Encrypt(ticket);
          var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted)
            {
              Expires = System.DateTime.Now.AddMinutes(timeout),
              HttpOnly = true
            };
          HttpContext.Current.Response.Cookies.Add(cookie);
        }
