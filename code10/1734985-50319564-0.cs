        public abstract class EditMemberBaseViewModel
        {
            [Required]
            public Something Something { get; set; }
        }
        public class EditMemberAsSecretaryViewModel : EditMemberBaseViewModel
        {
            [Required]
            public AnotherThing AnotherThing { get; set; }
        }
