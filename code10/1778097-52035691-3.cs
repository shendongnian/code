    User user = (User) activeDirectoryClient.Users.GetByObjectId("userobjectId").ExecuteAsync().Result;
    AppRoleAssignment appRoleAssignment = new AppRoleAssignment
    {
           Id = appRole.Id,
           ResourceId = Guid.Parse(newServicePrincpal.ObjectId),
           PrincipalType = "User",
           PrincipalId = Guid.Parse(user.ObjectId),
 
      };
    user.AppRoleAssignments.Add(appRoleAssignment);
    user.UpdateAsync().Wait();
