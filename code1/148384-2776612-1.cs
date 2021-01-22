        private const Guid DEFAULT_ORG = new Guid("3cbb9255-1083-4fc4-8449-27975cb478a5");
        public void Save(User user)
        {
            if (!DataContext.Users.Contains(user))
            {
                user.Id = Guid.NewGuid();
                user.CreatedDate = DateTime.Now;
                user.Disabled = false;
                user.OrganizationId = DEFAULT_ORG; // make the foreign key connection just
                                                   // via a GUID, not by assigning an
                                                   // Organization object
                DataContext.Users.InsertOnSubmit(user);
            }
            else
            {
                DataContext.Users.Attach(user);
            }
            DataContext.SubmitChanges();
        }
