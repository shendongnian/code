    class SomeClass
    {
        public void SomeFunctionThatDoesNotModifyState()
        {
        }
        public int SomeProperty
        {
            get
            {
                return someMember; // This is by-value, so no worries
            }
        }
        public SomeOtherClass SomeOtherProperty
        {
            get
            {
                return new SomeOtherClass(someOtherMember);
            }
        }
    }
