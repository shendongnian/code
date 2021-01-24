    public class PartialLoginViewModel
    {
        [Required]
        public string Nome { get; set; }
    }
    public class SomeModel : PartialLoginViewModel
    {
        // Code ...
    }
