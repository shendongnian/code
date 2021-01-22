    public enum State
    {
        Active = 1,
        Trial = 2,
        Canceled = 3
    }
    
    public class AccountStatus
    {
        public int Id {get; set;}
        public State State {get; set;}
        public string Description {get; set;}
        public bool IsActive {get; set;}
        public bool CanReactivate {get; set;}
    }
