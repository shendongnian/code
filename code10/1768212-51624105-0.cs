    [Serializable]
    public class UpdateException : Exception
    {
        public object databaseValues { get; set; }
        public UpdateException(object databaseValues)
        {
            this.databaseValues = databaseValues;
        }
        public UpdateException(string message, object databaseValues) :base(message)
        {
            this.databaseValues = databaseValues;
        }
    }
 
