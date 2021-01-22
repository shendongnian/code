    using System;
    using System.Collections.Generic;
    using System.Text;
    namespace businessTMS
    {
        public class SignIn
        {
            public string authenticate(String UserName, String password)
            {  
                dataTMS.SignIn data = new dataTMS.SignIn();
                return data.authenticate(UserName, password).ToString();
            }
    
        }
    }
