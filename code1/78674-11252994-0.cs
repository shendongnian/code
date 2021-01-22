    public static class WebExtensions
    {
    
    	/// <summary>
    	/// Selects the item in the list control that contains the specified value, if it exists.
    	/// </summary>
    	/// <param name="dropDownList"></param>
    	/// <param name="selectedValue">The value of the item in the list control to select</param>
    	/// <returns>Returns true if the value exists in the list control, false otherwise</returns>
    	public static Boolean SetSelectedValue(this DropDownList dropDownList, String selectedValue)
    	{
    		ListItem selectedListItem = dropDownList.Items.FindByValue(selectedValue);
    
    		if (selectedListItem != null)
    		{
    			selectedListItem.Selected = true;
    			return true;
    		}
    		else
    			return false;
    	}
    }
