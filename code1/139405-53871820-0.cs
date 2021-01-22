     public class ArgumentNullOrEmptyException : ArgumentNullException
    {
        #region Properties And Fields
        private static string DefaultMessage => $"A value cannot be null or empty{Environment.NewLine}";
        #endregion
        #region Construction and Destruction
        
        public ArgumentNullOrEmptyException()
            : base(DefaultMessage)
        {
        }
        public ArgumentNullOrEmptyException(string paramName)
            : base(paramName, 
                      $"{DefaultMessage}" +
                      $"Parameter name: {paramName}")
        {
        }
        public ArgumentNullOrEmptyException(string message, Exception innerException)
            : base($"{DefaultMessage}{message}", innerException)
        {
        }
        public ArgumentNullOrEmptyException(string paramName, string message)
            : base(paramName, 
                  $"{DefaultMessage}" +
                  $"Parameter name: {paramName}{Environment.NewLine}" +
                  $"{message}")
        {
        }
        #endregion
        public static void ThrowOnNullOrEmpty(string paramName, string paramValue)
        {
            if(string.IsNullOrEmpty(paramValue))
                throw new ArgumentNullOrEmptyException(paramName);
        }
        public static void ThrowOnNullOrEmpty(string paramValue)
        {
            if (string.IsNullOrEmpty(paramValue))
                throw new ArgumentNullOrEmptyException();
        }
        public static void ThrowOnNullOrEmpty(string paramName, object paramValue)
        {
            //ThrowOnNullOrEmpty another object that could be 'empty' 
            throw new NotImplementedException();
        }
    }
            private static void AFunctionWithAstringParameter(string inputString)
        {
            if(string.IsNullOrEmpty(inputString)) throw new ArgumentNullOrEmptyException(nameof(inputString));
            //Or ..
            ArgumentNullOrEmptyException.ThrowOnNullOrEmpty(nameof(inputString), inputString);
        }
