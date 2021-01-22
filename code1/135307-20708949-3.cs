    public class Model
    {
        [EmailAddress(ErrorMessage = "INVALID EMAIL")]
        public string Email {get; set;}
    }
