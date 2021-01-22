            List<Button> buttons = new List<Button>();
    		List<DropDownList> dropdowns = new List<DropDownList>();
    		foreach (Control c in Controls)
    		{
    			Button b = (c as Button);
    			if (b != null)
    			{
    				buttons.Add(b);
    			}
    
    			DropDownList d = (c as DropDownList);
    			if (d != null)
    			{
    				dropdowns.Add(d);
    			}
    		}
    
    		foreach (String key in Request.Form.Keys)
    		{
    			foreach (Button b in buttons)
    			{
    				if (b.UniqueID == key)
    				{
    					String id = b.ID.Replace("button_", "");
    					String unique_id = "ctl00$ContentPlaceHolder$Eng098Instructors_" + id;
    					Response.Write("MYID: " + id + "<br/>");
    
    					foreach (DropDownList d in dropdowns)
    					{
    						if (d.UniqueID == unique_id)
    						{
    							Response.Write("Instructor Selected: " + d.SelectedValue + "<br/>");
    							break;
    						}
    					} 
    				}
    			}	
    		}
