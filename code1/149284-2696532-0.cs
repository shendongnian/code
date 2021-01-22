        public class Account
        {    
            public string UserName {get; set;}             
            public string Password { get; set; }
            public string RePassword { get; set; }
            public string Name { get; set; }
            public string bd { get; set; }
            public string dt { get; set; }
            public string dc { get; set; }
        }
        public class ListAcc
        {
            static void Data()
            {
                List<Account> UserList = new List<Account>();
                //example of adding user account
                Account acc = new Account();
                acc.UserName ="John Doe";
                UserList.Add(acc);
            }
        }
