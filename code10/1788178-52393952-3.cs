    using System.Security;
      ...
       using (Session session = new Session())
       {
         session.ExecutableProcessUserName = "some_user_name";
         SecureString _Password = new SecureString();
         foreach (char _PasswordChar in "some_password")
         {
            _Password.AppendChar(_PasswordChar);
         }
         session.ExecutableProcessPassword = _Password;
         ... other session stuff...
         session.Open(options);
           ...more stuff...
         _Password.Dispose();
       } /* using() */
