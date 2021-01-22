    using Web.Extensions.ValidationAttributes;
    namespace Web.Areas.Staff.Models.Home
    {
        public class Person
        {
            [DisplayLabel(Lib.Const.LabelNames.HowOldAreYou)]
            public int Age { get; set; }
    
            [Required]
            public string Name { get; set; }
        }
    }
