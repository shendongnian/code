    public class BaseFooViewModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
    
        [DisplayName("Last Name")]
        public string LastName { get; set; }
    
        [DisplayName("Email Address")]
        [DataType("EmailAddress")]
        public string EmailAddress { get; set; }
    }
    public class FooDisplayViewModel : BaseFooViewModel
    {
        [DisplayName("ID Number")]
        public int Id { get; set; }
    }
    public class FooEditViewModel : BaseFooViewModel
