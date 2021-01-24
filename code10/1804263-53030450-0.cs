    public class CommentVM
    {
        public int? ID { get; set; } // if you also want to use this for editing existing comments
        [Required]
        public int? InquiryID { get; set; }
        [Required(ErrorMessage = "Please enter a comment")]
        public string Text { get; set; }
    }
