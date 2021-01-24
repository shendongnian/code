    string transition_id = "5";
    JObject issue_model = JObject.FromObject(new
    {
        update = new
        {
           comment = new[] { 
	     		new {
			    	add = new { 
                       body = "bug has been fixed" 
                    }
            	}
			}
         },
         fields = new
         {
             resolution = new { 
                 name = "namem vakye gere" 
             }
         },
         transition = new { 
            id = transition_id 
        }
    }
	);
