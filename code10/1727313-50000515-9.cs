        private int length; //This is an attribute of my class
        /* 
        * Declaring this within the class instead of the constructor allows it 
        * to be persisted in an instance of the class. This is a property.
        */
        public int[] myArray { get; set; }
        
        public MyClass(int myLength)
        {
                length = myLength;
                myArray = new int[length];
        }
        public int GetLengthPlusOne()
        {
            return length + 1;
        }
    }
