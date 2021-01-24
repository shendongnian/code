    class Test
    {
        int myVariable = 5;
     
        void TestA()
        {
            if (true)
            {
                while(true)
                {
                    ++myVariable; // this works, we can see myVariable
                }
            }
        }
        void TestB()
        {
            --myVariable; // this also works
        }
    }
