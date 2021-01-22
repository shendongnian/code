    bool exceptionthrown = false;
            while (!exceptionthrown)
            {
                try
                {
                    // Do magic here
                }
                catch (Exception)
                {
                    exceptionthrown = true;
                    throw;
                }
            }
