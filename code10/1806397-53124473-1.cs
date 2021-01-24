        public UsersDataGrid GetItem(string environment, long id)
        {
            ObjectContext objectContext = Common.getObjectContext(environment, false);
            try
            {
                var item = objectContext.CreateObjectSet<User>()
                    .Where(W => W.ID == id)
                    .Select(S => new UsersDataGrid()
                    {
                        Active = S.Active,
                        ID = S.ID,
                        Unique_ID = S.Unique_ID,
                        First_Name = S.First_Name.ToUpper(),
                        Last_Name = S.Last_Name.ToUpper(),
                        Email = S.Email,
                        School = S.School.Title.ToUpper(),
                        Gender = S.Gender.Title.ToUpper(),
                        TShirt_Size = S.TShirt_Size.Title.ToUpper(),
                        GUID = S.GUID + "",
                        Note = S.Note,
                        Machine_User = S.Machine_User,
                        Machine_Name = S.Machine_Name,
                        Created_On = S.Created_On,
                        Last_Updated_On = S.Updated_On
                    }).FirstOrDefault();
                return item;
            }
            catch (Exception exception)
            {
                return new UsersDataGrid()
                {
                    Note = ("Service Error: " +
                    Common.getInnerExceptionMessage(exception))
                };
            }
        }
