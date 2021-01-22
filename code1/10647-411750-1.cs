            void TrySuspectMethod()
            {
                try
                {
                    SuspectMethod();
                }
    #if DEBUG
                catch
                {
                    //Don't log error, let developer see 
                    //original stack trace easily
                    throw;
    #else
                catch (Exception ex)
                {
                    //Log error for developers and then 
                    //throw a error with a user-oriented message
                    throw new Exception(String.Format
                        ("Dear user, sorry but: {0}", ex.Message));
    #endif
                }
            }
