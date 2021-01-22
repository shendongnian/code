    class MyClass 
    {  
        ... stuff ...   
        public string MyProperty 
        {    
            private string _myBackingField;    
            get 
            { 
                if (_myBackingField == null)
                {
                    myBackingField = ... load field ...;
                }
                return _myBackingField; 
            }    
            set { _myBackingField = value; }  
        }
    }
