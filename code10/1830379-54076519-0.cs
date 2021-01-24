        public static class ExceptionHelper
        {
            private static Dictionary<int, string> TechnicalErrorDictionary = new Dictionary<int, string> {{ 1001, "User with id {0} does not exist" }, { 1002, "Created user with id {0}" }, { 2002, "User with id {0} with type {1} is invalid" }, { 3003, "Unexpected server error" }, { 4001, "Some text with {0} and another {1} included on {2}" } };
            /// <exception cref = "KeyNotFoundException">the errorCode did not exist in dictionary</exception>
            public static TechnicalException CreateTechnicalException(int errorCode, params object[] para)
            {
                return new TechnicalException(errorCode, string.Format(TechnicalErrorDictionary[errorCode], para));
            }
        }
