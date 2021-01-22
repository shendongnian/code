    private string address = null;
    public string Address
    {
        get
        {
            if (this.address == null)
            {
                 // Load on first use: This might make a problem...
                 UserProfile profile = UserProfile.GetUserProfile(UserName);
                 this.address = profile.Address;
            }
            return this.address;
        }
        set
        {
            this.address = value;                      
        }
    }   
