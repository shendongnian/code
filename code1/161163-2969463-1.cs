    private string SpacedString(string myOldString)
    {
    
    			System.Text.StringBuilder newStringBuilder = new System.Text.StringBuilder("");
    			foreach (char c in myOldString.ToCharArray())
    			{
    				newStringBuilder.Append(c.ToString() + ' ');
    			}
    
    			string MyNewString = "";
    			if (newStringBuilder.Length > 0)
    			{
    				// remember to trim off the last inserted space
    				MyNewString = newStringBuilder.ToString().Substring(0, newStringBuilder.Length - 1);
    			}
    			// no else needed if the StringBuilder's length is <= 0... The resultant string would just be "", which is what it was intitialized to when declared.
    			return MyNewString;
    }
