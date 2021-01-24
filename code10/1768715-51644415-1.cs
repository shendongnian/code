        private void CallThisToForceRefrence()
        {
            int x = 0;
            x = 1;
            x = (x + 1);
            if (x == 42)
            {
                DummyForRoslyn(); //will never execute
            }
            return;
        }
        private void DummyForRoslyn()
        {
            System.DirectoryServices.AccountManagement.PrincipalContext fakeCtx = new System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain, "FakeNeverGoingToExecute");
            int sillyNum = 0;
            sillyNum = (int)fakeCtx.ContextType;
            if (sillyNum == (int)System.DirectoryServices.AccountManagement.ContextType.Domain)
            {
                // Does this Enum Refrence Force Roslyn to Go Looking in a First Refrence - First Compile Scenario ?
                sillyNum = 42;
            }
            return;
        }
