        public static void GetUser_Firebase(User user, FirebaseApp app)
        {
    	FirebaseDatabase database = FirebaseDatabase.GetInstance(app);
    	DatabaseReference reference = database.GetReference($"/users/{user.UserID}");
    	//"Using for getting firebase information", $"/users/{user.UserID}"
    	reference.AddListenerForSingleValueEvent(new UserInfo_DataValue());
        }
    
    class UserInfo_DataValue : Java.Lang.Object, IValueEventListener
    {
    	private string ID;
     public UserInfo_DataValue(string uid)
     {
    	  this.ID = uid;
    	}
    	public void OnCancelled(DatabaseError error)
    	{
    		//"Failed To Get User Information For User "
    	}
    
    	public void OnDataChange(DataSnapshot snapshot)
    	{
    		Dictionary<string, string> Map = new Dictionary<string, string>();
    		var items = snapshot.Children?.ToEnumerable<DataSnapshot>(); // using Linq
    		foreach(DataSnapshot item in items)
    		{
    			try
    			{
    				Map.Add(item.Key, item.Value.ToString()); // item.value is a Java.Lang.Object
    			}
    			catch(Exception ex)
    			{
    				//"EXCEPTION WITH DICTIONARY MAP"
    			}
    		}
    		User toReturn = new User();
    		toReturn.UserID this.ID;
    		foreach (var item in Map)
    		{
    			switch (item.Key)
    			{
    				case "email":
    					toReturn.email = item.Value;
    					break;
    				case "lastName":
    					toReturn.lastName = item.Value;
    					break;
    				case "name":
    					toReturn.name = item.Value;
    					break;
    				case "phone":
    					toReturn.phone = item.Value;
    					break;                        
    			}
    		}
    	}
    }
