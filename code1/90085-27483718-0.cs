        string user = "Steve"; // The username you are trying to get the profile for.
        bool isAuthenticated = false;
        
            MembershipUser mu = Membership.GetUser(user);
            if (mu != null)
            {
                // User exists - Try to load profile 
                
                ProfileBase pb = ProfileBase.Create(user, isAuthenticated);
        
                if (pb != null)
                {
                    // Profile loaded - Try to access profile data element.
                    // ProfileBase stores data as objects in a Dictionary 
                    // so you have to cast and check that the cast succeeds.
            
                    string myData = (string)pb["MyKey"];
            
                    if (!string.IsNullOrWhiteSpace(myData))            
                    {
                        // Woo-hoo - We're in data city, baby!
                        Console.WriteLine("Is this your card? " + myData);
                    }
                }        
            }
	    
