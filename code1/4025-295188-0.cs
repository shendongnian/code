            // Begin try
                 DoSomething(); // throws FaultException<FooFault>
            // End try
            if (exceptionOccured)
            {
                if(exception is FaultException) // FE catch block.
                {
                    throw;
                    // Goto Exit
                }
                if(exception is Exception) // EX catch block
                {
                    throw new FaultException<FooFault>();
                    // Goto Exit
                }
            }
            // Exit
