    public class AlphaViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        ....
        bool HasBeta { get; set; }
        
        // Include properties from BetaViewModel
        [HiddenInput]
        [RequiredIf("HasBeta ", true)]
        public string Id { get; set; }
        [RequiredIf("HasBeta ", true, ErrorMessage = "...")]
        public string Location { get; set; }
        [RequiredIf("HasBeta ", true, ErrorMessage = "...")]
        public string Area { get; set; }
    }
    
