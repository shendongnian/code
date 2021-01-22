    [Serializable]
    public class EmailValidationException : Exception
    {
        // overriden constructors would go here
        private List<string> _validationMessages = new List<string>();
        // store your validation exception messages in a collection
        public ReadOnlyCollection<string> ValidationMessages 
        {
            get
            {
                return _validationMessages.AsReadOnly();
            }
        }
    }
