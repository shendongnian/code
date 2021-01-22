    public enum Role
    {
    	None = Permission.None,
    	Guest = Permission.Browse,
    	Reader = Permission.Browse| Permission.Help ,
    	Manager = Permission.Browse | Permission.Help | Permission.Customise
    }
