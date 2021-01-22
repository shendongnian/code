            public static void CreateEntity()
            {
                User user = null;
                using (DataClassesDataContext dc = new DataClassesDataContext())
                {
                    user = (from u in dc.Users
                            select u).FirstOrDefault();               
                }
                UpdateObject(user);
            }
    
            public static void UpdateObject(User user)
            {
                using (DataClassesDataContext dc = new DataClassesDataContext())
                {
                    dc.Users.Attach(user);
                    user.LastName = "Test B";
                    dc.SubmitChanges();
                }
            }
