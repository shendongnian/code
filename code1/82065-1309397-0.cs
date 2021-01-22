    partial class myPage : IMyTaggablePage
    {
        // the following is an interface member
        public List<string> GetTags()
        {
            return this.Taglist; // assuming taglist was populated somewhere on this page.
        }
    }
