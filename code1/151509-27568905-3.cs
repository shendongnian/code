     //I select some roles from my ORM my with subrequest and save results to Tuple list
     var rolesWithUsers = (from role in roles
                           select new Tuple<string, int, int>(
                             role.RoleName, 
                             role.RoleId, 
                             usersInRoles.Where(ur => ur.RoleId == role.RoleId).Count()
                          ));
     //Then I add some new element required element to this collection
     var tempResult = rolesWithUsers.ToList();
     tempResult.Add(new Tuple<string, int, int>(
                            "Empty", 
                             -1,
                             emptyRoleUsers.Count()
                          ));
     //And create a new anonimous class collection, based on my Tuple list
     tempResult.Select(item => new
                {
                    GroupName = item.Item1,
                    GroupId = item.Item2,
                    Count = item.Item3
                });
     //And return it in JSON
     return new JavaScriptSerializer().Serialize(rolesWithUsers);
