    public IP(string address) : this()
    {
        Address = address;
        Domain = "";
        Notes = "";
        FirstAccess = DateTime.Now;
        LastAccess = DateTime.Now;
    }
