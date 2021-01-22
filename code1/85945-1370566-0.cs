        public IList<UserAccount> List()
        {
            var list = new FluentCommand<UserAccount>("SELECT ID, UserName, Password FROM UserAccount")
                .SetMap(reader => new UserAccount
                {
                    ID = reader.GetInt("ID"),
                    Password = reader.GetString("Password"),
                    UserName = reader.GetString("UserName"),
                })
                .AsList();
            return list;
        }
