    public IP(string address) {
    Address = address;
    Domain = "";
    Notes = "";
    FirstAccess = DateTime.Now;
    LastAccess = DateTime.Now;
    this._Sessions = new EntitySet<Session>(new Action<Session>(this.attach_Sessions), new Action<Session>(this.detach_Sessions));
    OnCreated(); }
