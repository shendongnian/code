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
                ).ToDictionary(x=>x.User,y=>y);
    
    
    
    var usernameToUpdate = "username123";
    var newPassword = "Thisisnewpassword";
    
    users[usernameToUpdate] = new 
    							{
    								FirstName = users[usernameToUpdate].FirstName, 
    								User = users[usernameToUpdate].User,
    								Password =  newPassword
    								};
    								
    
    var newFileData = String.Join(Environment.NewLine, 
                           users.Select(x=> $"{x.Value.FirstName} ~{x.Value.User}~{x.Value.Password}"));
    File.WriteAllText(fileName, newFileData);
