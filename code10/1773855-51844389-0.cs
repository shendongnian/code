    class User
    {
        public virtual int id { get; set; }
        public virtual string username { get; set; }
        public virtual string password { get; set; }
        public virtual string role { get; set; }
        public virtual bool deleted { get; set; }
        public virtual DateTime create_date { get; set; }
    }
