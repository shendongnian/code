    public MyTextbox:Textbox
    {
        public Event EventHandler TextChanged
        {
            add
            {
               //set the base
               //store locally
            }
            remove
            {
               //remove from base
               //remove from local store
            }
        }
    
        public string Text
        {
            get
            {
                //return the base
            }
            set
            {
               //remove local handlers from base
               //set value in base
               //reassign handlers.
            }
        }
    }
