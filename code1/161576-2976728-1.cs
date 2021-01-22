    class ClassName //Classes are capitilzed
    {
        public ClassName(int myProperty) //Constructor arguments are named the same as the property they set.
        {
           _myProperty = myPropriety;
        }
        public void MyFunction(object varToBePassed) //Function names are captilized, passed pramaters are lowercase.
        {
            int sampleVar; //local variables are lowercase
        }
        public int MyProperty { get { return _myProperty; } } // Properties are capitalized
        private int _myProperty; // Private fields are lowercase and start with a _
