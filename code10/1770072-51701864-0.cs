    /// <param name="graphClient"></param>
      /// <param name="groupId"></param>
      /// <param name="memberId">memberId/sub-group id</param>
      /// <returns></returns>
        public static async Task AddGroupMember1(GraphServiceClient 
        graphClient, string groupId, string memberId)
        { 
             User memberToAdd = new User { Id = memberId };
            //Group memberToAdd= new Group { Id = memberId };
            await graphClient.Groups[groupId].Members.References.Request().AddAsync(memberToAdd); 
       }
