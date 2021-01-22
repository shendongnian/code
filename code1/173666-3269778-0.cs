    public static class Util
    {
    	public static IEnumerable<string> GetUsernames(GridView gv)
    	{
    		List<string> userNames = new List<string>();
    		foreach (GridViewRow row in gv.Rows)
    		{
    			CheckBox cb = (CheckBox)row.FindControl("chkRows");
    			if (cb != null && cb.Checked)
    			{
    				// get the row index values (DataKeyNames) and assign them to variable
    				string userName = gv.DataKeys[row.RowIndex].Value.ToString();
    				userNames.Add(userName);
    			}
    		}
    		return userNames;
    	}
    }
