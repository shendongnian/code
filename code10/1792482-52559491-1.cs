     protected void IdentitySignout()
            {
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie,
                                                DefaultAuthenticationTypes.ExternalCookie);
            }
