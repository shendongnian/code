    IEnumerable<RoleIdCombination> CreateRoleIdCombinations(
        IEnumerable<char> roles,
        IEnumerable<int> ids)
    {
         foreach (var role in roles)
         {
             foreach (var id in ids)
             {
                  yield return new RoleIdCombination
                  {
                      Role = role,
                      Id = id,
                  };
             }
         }
    }
