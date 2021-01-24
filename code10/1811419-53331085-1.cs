    public class AssignClaimToUserModel : PageModel
    {
        public ClaimToUserdModel ClaimToUserdModel;
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(ClaimToUserdModel model)
        {
            return null;
        }
    }
    public class ClaimToUserdModel
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public Guid UserId { get; set; }
        public bool IsRole { get; set; }
    }
