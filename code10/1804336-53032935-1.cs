    class Test
    {
        void TestA()
        {
            int myVariable = 5;
        }
        void TestB()
        {
            // can't see MyVariable because it's in a different scope, and that scope isn't above the current scope
        }
        void TestC()
        {
            {
                int myOtherVariable = 5;
            }
            // can't see myOtherVariable because it was defined in a child scope of this method scope
        }
    }
