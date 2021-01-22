        class CDDtype
        {
            public int Id { get; set; }
            public DDType DDType { get; set; }
    
            public CDDtype()
            {
                DDType = DDType.None;
            }
        }    
    
        
        [DefaultValue(None)]
        public enum DDType
        {       
            None = -1,       
            ON = 0,       
            FC = 1,       
            NC = 2,       
            CC = 3
        }
