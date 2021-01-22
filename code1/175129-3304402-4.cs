        void DoSomethingWithDrWilyEvilBoobyTrap()
        {
            Dr.Wily.Evil.BoobyTrap trap = null;
            try
            {
                trap = new Dr.Wily.Evil.BoobyTrap(Dr.Wily.Evil.Evilness.Very);
                // do something with booby trap
            }
            catch (Exception ex)
            {
                // handle exceptions
            }
            finally
            {
                if (trap != null) // Exception thrown here!
                    trap.Dispose(); // Exception thrown here as well!
            }
        }
