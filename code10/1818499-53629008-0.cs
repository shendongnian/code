    class SomeObject
    {
            public System.Action<SomeObject> Action {get; set;}
    
            public string Status {get; set;}
    
            public SomeObject() : this(null)
            {
            }
    
            public SomeObject(System.Action<SomeObject> action)
            {
                this.Action = action;
            }
    
            public void Execute()
            {
                this.Action(this);
            }
    }
