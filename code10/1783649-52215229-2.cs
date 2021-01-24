    public int UserStatus
        {
            get { return userstatus; }
            set
            {
                if (value!=userstatus)
                {
                   userstatus = value;
                   OnPropertyChanged(nameof(UserStatus)); 
                } 
            }
        }
