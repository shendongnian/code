    public sealed class TriggerField<T>
    {
        private T data;
    	
        ///<summary>raised *after* the value changes, (old, new)</summary>
        public event Action<T,T> OnSet;
    	
        public TriggerField() { }
    	
        ///<summary>the initial value does NOT trigger the onSet</summary>
        public TriggerField(T initial) { this.data=initial; }
    	
        public TriggerField(Action<T,T> onSet) { this.OnSet += onSet; }
    
        ///<summary>the initial value does NOT trigger the onSet</summary>
        public TriggerField(Action<T,T> onSet, T initial) : this(onSet) 
        { 
            this.data=initial;
        }
    	
        public T Value
        {
            get { return this.data;}
            set 
            { 
                var old = this.data;
                this.data = value;
                if (this.OnSet != null)
                    this.OnSet(old, value);
            }
        }
    }
