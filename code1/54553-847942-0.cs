    class OuterClass
    {
        private InnerClass innerClass
    
        public int M_A
        {
            get
            {
                if (this.innerClass != null)
                {
                     return this.innerClass.M_A;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            set
            {
                if (this.innerClass != null)
                {
                     this.innerClass.M_A = value;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
