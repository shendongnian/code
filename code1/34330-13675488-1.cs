    public interface IModel {
        [Required]
        [DisplayName("Foo Bar")]
        string FooBar { get; set; }
    } 
    public class Model : IModel {
        public string FooBar { get; set; }
    }
