        /// <summary>
        /// Provides a default pattern to access the current user in the session, identified
        /// by forms authentication.
        /// </summary>
        public abstract class MySession<T> where T : class
        {
            public const string USERSESSIONKEY = "CurrentUser";
    
            /// <summary>
            /// Gets the object associated with the CurrentUser from the session.
            /// </summary>
            public T CurrentUser
            {
                get
                {
                    if (HttpContext.Current.Request.IsAuthenticated)
                    {
                        if (HttpContext.Current.Session[USERSESSIONKEY] == null)
                        {
                            HttpContext.Current.Session[USERSESSIONKEY] = LoadCurrentUser(HttpContext.Current.User.Identity.Name);
                        }
                        return HttpContext.Current.Session[USERSESSIONKEY] as T;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
    
            public void LogOutCurrentUser()
            {
                HttpContext.Current.Session[USERSESSIONKEY] = null;
                FormsAuthentication.SignOut();
            }
    
            /// <summary>
            /// Implement this method to load the user object identified by username.
            /// </summary>
            /// <param name="username">The username of the object to retrieve.</param>
            /// <returns>The user object associated with the username 'username'.</returns>
            protected abstract T LoadCurrentUser(string username);
        }
    
    }
