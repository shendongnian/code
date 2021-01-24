    public class StoryDetailsViewModelSignedInUser
    {
        public bool IsAnonymous
        {
            get
            {
                return User != null;
            }
        }
        public ApplicationUser User { get; set; }
        // other properties here
    }
