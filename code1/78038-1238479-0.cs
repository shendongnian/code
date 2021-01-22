    class MyClass : BaseClass
    {
        //local value
        private bool local;
        //first access yet?
        private bool accessed = false;
        // Override base property.
        public new bool MyProperty
        {
            get
            {
                if(!accessed)
                {
                    // modify first-get case according to your taste, e.g.
                    local = base.MyProperty;
                    accessed = true;
                    RaiseMyPropertyChangedBeforeUseEvent();
                }
                else
                {
                    if(local != base.MyProperty)
                    {
                        local = base.MyProperty;
                        RaiseMyPropertyChangedBeforeUseEvent();
                    }
                }
                return local;
            }
            set
            {
                base.MyProperty = value;
            }
        }
    }
