    class ClassName //Classes are capitilzed
    {
        public ClassName(int myPropriety)
        {
           _myPropriety = myPropriety;
        }
        public void MyFunction(object varToBePassed) //Function names are captilized, passed pramaters are lowercase.
        {
            int sampleVar; //local variables are lowercase
        }
        public int MyPropriety { get { return _myPropriety; } } // Proprieties are caplized
        private int _myPropriety; // Fields are lowercase and start with a _
