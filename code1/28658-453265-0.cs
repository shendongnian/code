    interface IFoo 
    { 
        int Offset { get;}
    }
    
    interface IBar : IFoo 
    {
        new int Offset { set; } 
    }
    
    class Thing : IBar 
    {
        public int Offset { get; set; }
    
        int IFoo.Offset
        {
            get
            {
                return this.Offset;
            }
        }
    
        int IBar.Offset {
            set
            {
                this.Offset = value;
            }
        }
    }
