        private bool userstatus;
    
    
        public bool UserStatus
        {
            get { 
                   return userstatus;
            }
            set
            {
                userstatus = value;
                OnPropertyChanged("UserStatus");
            }
        }
