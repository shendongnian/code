    string str = System.IO.File.ReadAllText(fileName);
    var users = str.Split(new []{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries)
    			.Select(x=>
    			  new 
                   { 
                     User =	x.Split(new []{","},StringSplitOptions.RemoveEmptyEntries)[0],
    			     Password = x.Split(new []{","},StringSplitOptions.RemoveEmptyEntries)[1]
                   }
                ).ToDictionary(x=>x.User,y=>y.Password);
    			
    
    
    var usernameToUpdate = "username1";
    var newPassword = "password1";
    
    users[usernameToUpdate] = newPassword;
    
    var newFileData = String.Join(Environment.NewLine, 
                           users.Select(x=> $"{x.Key},{x.Value}"));
    File.WriteAllText(fileName, newFileData);
