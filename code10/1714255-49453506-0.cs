        class Player
        {
            public object Id;
            public object Name; 
           
        }
    
        class UserPlayer : Player
        {
            public new int Id
            {
                get
                {
                    return Convert.ToInt32(base.Id);
                }
                set
                {
                    base.Id = value;
                }
    
            }
            public new string Name
            {
                get
                {
                    return base.Name.ToString();
                }
                set
                {
                    base.Name = value;
                }
            }
       }
