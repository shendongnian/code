        protected delegate void OutStringDelegate(int divider, out string errorText);
        protected void codeWrapper(int divider, OutStringDelegate del)
        {
            string ErrorMessage = "An Error Occurred.";
            try
            {
                del(divider, out ErrorMessage);
            }
            catch
            {
                LogError(ErrorMessage);
            }
        }
        public void UseWrapper(int input)
        {
            codeWrapper(input, codeToCall);
        }
        private int somePrivateValue = 0;
        private void codeToCall(int divider, out string errorMessage)
        {
            errorMessage = "Nice Error Message here!";
            somePrivateValue = 1 / divider; // call me with zero to cause error.
        }
        private void LogError(string msg)
        {
            Console.WriteLine(msg);
        }
