    interface IField
    {
        bool IsValid { get; }
    }
    class Field : IField
    {
        public bool IsValid { get; protected set; }
    }
