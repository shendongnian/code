     private void Login_Clicked()
        {
            
            database = new Database();
            var Logindata = database.GetUsername(_usernamelogin);
            if (string.IsNullOrWhiteSpace(_usernamelogin) || string.IsNullOrWhiteSpace(_passwordlogin))
            {
                // your code
            }
            else
            {
                if (Logindata != null)
                {
                    if (Logindata.UserName == _usernamelogin && Logindata.Password == _passwordlogin)
                    {
                          // your code
                    }
                    else
                    {
                          // your code
                    }
                }
                else
                {
                       // your code
                }
            }
        }
