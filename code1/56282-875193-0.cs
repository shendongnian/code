    using (var context = new DBDataContext())
    {
        var request = new PublisherRequest
                      {
                         UserId = UserId,
                         PageUrl = Url,
                         TypeId = TypeId
                      };
        for (var categoryId in CategoryIds)
        {
             request.PubReqCategories.Add( new PubReqCategory
                                           {
                                               CategoryId = categoryId 
                                           } );
        }
        context.PublisherRequests.InsertOnSubmit( request );
        context.SubmitChanges();
    }
