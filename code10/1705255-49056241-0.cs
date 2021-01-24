            [DataContract]
            class UserProvisioning
            {
                [DataMember]
                public String useraccountid
                {
                    get { return this.useraccountid; }
                    set { this.useraccountid = value; }
                }
            
                // will be set on runtime
                public DateTime createdon
                {
                    get { return this.createdon; }
                    set { this.createdon = value; }
                }
    //Must declare this for the child list of Profile
                [DataMember]
                public List<Profile> profiles {get;set;}=new List<Profile>();
            }
