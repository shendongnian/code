        private void GlobalTryCatch(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (ExpectedException1 e)
            {
                throw MyCustomException("Something bad happened", e);
            }
            catch (ExpectedException2 e)
            {
                throw MyCustomException("Something really bad happened", e);
            }
        }
        public void DoSomething()
        {
            GlobalTryCatch(() =>
            {
                // Method code goes here
            });
        }
