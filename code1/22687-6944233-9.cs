    using Web.Extensions.ValidationAttributes;
    namespace Web.Areas.Foo.Models
    {
        public class Person
        {
            [DisplayLabel(Lib.Const.LabelNames.HowOldAreYou)]
            public int Age { get; set; }
    
            [Required]
            public string Name { get; set; }
        }
    }
