    IGroupMembersCollectionWithReferencesPage users = _gsc.Groups["GROUP_ID"].Members.Request().GetAsync().Result;
    do
    {
       
       Console.WriteLine("number:" + users.Count);
       foreach (var usr in users)
       {
           Console.WriteLine("user: {0}", usr.Id);
       }
    } 
    while(users.NextPageRequest != null && (users = users.NextPageRequest.GetAsync().Result).Count > 0);
