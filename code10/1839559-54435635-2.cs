    class RoleIdCombination
    {
        public char Role {get; set;}
        public int Id {get; set;}
    }
    // let your process create the requested RoleIdCombinations:
    var roleIdCombinations = CreateRoleIdCombinations(roles, ids);
    // do only one query:
    var result = dbContext.TableNames
        .Select(tableName => new
        {
             // for easier equality check: make a RoleIdCombination:
             RoleIdCombination = new RoleIdCombination
             {
                  Role = tableName.Role,
                  Id = tableName.Id,
             }
             // remember the original item
             TableName = tableName,
         })
        .Where(item => roleIdCombinations.Contains(item.RoleIdCombination));
