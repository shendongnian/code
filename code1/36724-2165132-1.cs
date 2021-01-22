    public class AClassThatReferencesItself
        {
            private AClassThatReferencesItself _other;
    
            private string myString;
    
            [NotNullValidator]
            public string MyString
            {
                get { return myString; }
                set { myString = value; }
            }
    	
    
            [RuntimeObjectValidator]
            [NotNullValidator]
            public AClassThatReferencesItself Other
            {
                get { return _other; }
                set { _other = value; }
            }
    	
        }
