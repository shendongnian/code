        public void EnumerateConstants() {        
            FieldInfo[] thisObjectProperties = thisObject.GetFields();
            foreach (FieldInfo info in thisObjectProperties) {
                if ((info.Attributes & FieldAttributes.Literal) != 0) {
                    //Constant
                }
            }    
        }
