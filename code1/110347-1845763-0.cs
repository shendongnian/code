    class MyClass
    {
        public int SomeVariable;
        
        public void SomeMethod()
        {
            int SomeVariable;
            SomeVariable = 4; // This assigns the local variable.
            this.SomeVariable = 6; // This assigns the class member.
        }
    }
