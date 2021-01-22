    class Form
        {
            public IList<IFormField> Fields
            {
                get
                {
                    return new List<IFormField>(){
                            new IntegerFormField(10, "c1"), 
    new DecimalFormField(200, "c2")
                     };
                }
            }
        }
    
    
        
