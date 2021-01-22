    class ClassName //Classes are PascalCase
    {
        public ClassName(int myProperty) //Constructor arguments are named the same as the property they set but use camelCase.
        {
           _myProperty = myPropriety;
        }
        public void MyFunction(object varToBePassed) //Function names are PascalCase, passed pramaters are camelCase.
        {
            int sampleVar; //local variables are camelCase
        }
        public int MyProperty { get { return _myProperty; } } // Properties are PascalCase
        private int _myProperty; // Private fields are camelCase and start with a _
