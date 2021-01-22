        class StackOver : MarshalByRefObject
        {
            public void Run()
            {
                Run(); // Recursive call with no termination
            }
        }
