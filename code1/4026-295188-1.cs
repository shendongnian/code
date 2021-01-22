            try
            {
                try
                {
                    DoSomething(); // throws FaultException<FooFault>
                }
                catch (Exception ex)
                {
                    if (ex is FaultException<FooFault>)
                        throw;
                    else
                        myProject.Exception.Throw<FooFault>(ex);
                }
            }
            catch (FaultException)
            {
                throw;
            }
