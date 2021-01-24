    TfsConfigurationServer tcs = new TfsConfigurationServer(new Uri("http://tfsurl:8080/tfs"));
    
    IIdentityManagementService ims = tcs.GetService<IIdentityManagementService>();
    
    TeamFoundationIdentity tfi = ims.ReadIdentity(IdentitySearchFactor.AccountName, "[TEAM FOUNDATION]\\Team Foundation Valid Users", MembershipQuery.Expanded,ReadIdentityOptions.None);
    
    TeamFoundationIdentity[] ids = ims.ReadIdentities(tfi.Members, MembershipQuery.None, ReadIdentityOptions.None);
    List<string> allUsers = new List<string>;
    foreach (TeamFoundationIdentity id in ids)
    { 
      if (id.Descriptor.IdentityType == "System.Security.Principal.WindowsIdentity")
      {
      allUsers.Add(id.DisplayName)  
      }
    }
