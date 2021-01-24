    [Serializable]
    class AuthenticationException : Exception
    {
        public int PracticeId { get; }
    
            // Other constructors
    
        // Option A
        public AuthenticationException(int practiceId)
            : base()
        {
            PracticeId = practiceId;
        }
    
        // Option B
        public AuthenticationException(int practiceId)
            : base("Invalid id: " + practiceId)
        {
            PracticeId = practiceId;
        }
    }
