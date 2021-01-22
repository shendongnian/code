    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    using Newtonsoft.Json;
    
    class Users
    {
        public string Name {get; set;}
        public int UserID {get; set;}
        public Users(string Name, int UserID)
        {
    	    this.Name = Name;
    	    this.UserID = UserID;
        }
    }
    	List<Users> users = new List<Users>();
    	users.Add(new Users("John", 1));
    	users.Add(new Users("Mary", 2));
        ...    	
    	string json = JsonConvert.SerializeObject(from user in users select user.UserID);
    }
