    class Example
        {
            private bool userNameLoaded = false;
            private string userName = "";
            public string UserName(bool refresh)
            {
                userNameLoaded = !refresh;   
                return UserName();
            }
            public string UserName()
            {
                if (!userNameLoaded)
                {
                    /*
                    userName=SomeDBMethod();
                    */
                    userNameLoaded = true;                    
                }
                return userName;         
            }
        }
