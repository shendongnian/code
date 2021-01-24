    string str = System.IO.File.ReadAllText(fileName);
    var users = str.Split(new []{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries)
                .Select(x=>
    			{
    			  var strArray = x.Split(new []{"~"},StringSplitOptions.RemoveEmptyEntries);
                  return new 
                   { 
    			   	 FirstName = strArray[0],
                     User = strArray[1],
                     Password = strArray[2]
                   };
    			}
                );
    
    var usernameToUpdate = "username123";
    var newPassword = "Thisisnewpassword";
    
    var updatedList = users.Select(x => x.User.Equals(usernameToUpdate) ? 
				            $"{x.FirstName} ~{x.User}~{newPassword}"
							: $"{x.FirstName} ~{x.User}~{x.Password}").ToList();
    var newFileData = String.Join(Environment.NewLine, 
                       updatedList);
    File.WriteAllText(fileName, newFileData);
