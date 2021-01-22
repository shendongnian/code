     public void PopulateUserDDL(UnitOfWork UnitOfWorkObject)
     {
         List<User> UserCollection = mUserService.GetUserCollection();  //get a collection of objects to bind this ddl
        
         List<ILookupDTO> UserLookupDTO = new List<ILookupDTO>();
        
         UserLookupDTO.Add(new User(" ", "0"));
         //insert a blank row ... if you are into that type of thing
        
         foreach (var User in UserCollection) {
             UserLookupDTO.Add(new User(User.FullName, User.ID.ToString()));
         }
        
         LookupCollection LookupCollectionObject = new LookupCollection(UserLookupDTO);
         LookupCollectionObject.BindTo(mView.UserList);
        
         if (UnitOfWorkObject == null) {
             return;
         }
        
         if (UserCollection == null) {
             return;
         }
        
         for (i = 0; i <= UserCollection.Count - 1; i++) {
             if (UserCollection(i).ID == UnitOfWorkObject.User.ID) {
                 LookupCollectionObject.SelectedIndex = (i + 1);
                 //because we start at 0 instead of 1 (we inserted the blank row above)
                 break;
             }
         }
     }
