    class SomeClass
    {
        // inside a class, an interface can have access modifiers
        private interface IPrivateTest
        { 
            void TestMe();    // always public, cannot even use "public" keyword
        }    
    }
