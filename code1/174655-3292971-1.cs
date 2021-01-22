        {
            SomeType withDispose = new SomeType();
            try
            {
                 // use withDispose
            }            
            finally 
            {
                if (withDispose != null)
                {
                     ((IDisposable)withDispose).Dispose();
                }
            }
        }
