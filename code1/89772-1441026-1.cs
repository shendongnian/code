    class TestClass
    {
        private bool isMyPropertyReadOnly;
    
        public bool IsMyPropertyReadOnly
        {
            get { return isMyPropertyReadOnly; }
            set { isMyPropertyReadOnly = value; }
        }
        
        private int myVar;
    
        public int MyProperty
        {
            get { return myVar; }
            
            set
            {
                if (isMyPropertyReadOnly)
                {
                    throw new System.Exception("The MyProperty property is read-only.");
                }
                else
                {
                    myVar = value;
                }
            }
        }
    }
