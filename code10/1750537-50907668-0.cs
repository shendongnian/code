    public class BaseModel
    {
       [Required]
       public string RequiredProperty { get; set; }
    }
    public class DerivativeModel : BaseModel
    {
        new public string RequiredProperty { get; set; }
    }
