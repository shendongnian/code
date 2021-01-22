        public void Foo()
        {
            try
            {
                // Some service adapter code
                // A call to the service
            }
            catch (ServiceBoundaryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AdapterBoundaryException("some message", ex);
            }
        }
