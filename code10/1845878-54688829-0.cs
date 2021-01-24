        Exception exception = null;
            try
            {
                // Code to be tested goes here...
            }
            catch (Exception e)
            {
                exception = e;
            }
            Assert.IsInstanceOfType(exception, typeof(DesiredExceptionClass));
