      public class CommentaarCreate_VM
        {
            public Stad Stad { get; set; }
            [Required(AllowEmptyStrings=false, ErrorMessage="You need to enter a comment of valid length")]
            [MinLength(5, ErrorMessage ="You need to enter a comment of valid length")]
            public Commentaar Commentaar { get; set; }
        }
