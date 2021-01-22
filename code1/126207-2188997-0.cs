    function List<string> GetGroupNames(string userName)
    {
      var pc = new PrincipalContext(ContextType.Domain);
      var src = UserPrincipal.FindByIdentity(pc, userName).GetGroups(pc);
      var result = new List<string>();
      src.ToList().ForEach(sr => result.Add(sr.SamAccountName));
      return result;
    }
    
