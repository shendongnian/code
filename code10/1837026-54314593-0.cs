    public UserKycCompositeModel(UserDetails userDetails, Documents documents)
    {
         Id = userDetails.Id;
         DoB = userDetails.DoB;
         Name = userDetails.Name;
         // any other properties from userDetails
         DocumentId = documents.Id;
         UserIdFK = documents.UserIdFK;
         ImagePath = documents.ImagePath;
         // any other properties from documents
    }
