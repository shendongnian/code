    public class Customer
    {
        [StringLengthValidator(20)]
        public virtual string CustomerId { get; set;}
    }
