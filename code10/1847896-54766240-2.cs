    [Serializable]   //// This is required when using out of proc session state
    public class MySessionState
    {
        public string Username {get; set;}
        public string Role {get; set;}
        public string FirstName{get; set;}
        public string LastName {get; set;}
        public int Age{get; set;}
    }
