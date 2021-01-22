     public void SaveUser(User UserObject)
     {
         if (UserObject.IsValid()) {
             mRepository.SaveUser(UserObject);
         }
     }
