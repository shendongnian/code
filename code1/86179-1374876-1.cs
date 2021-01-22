    public class SingleLoadControl: UserControl, IPostingControl {
        // ... rest of the implementation
        public void SetVisibility(PostingType postingType, bool isMultiPost) {
            this.Visible = postingType == PostingType.Load && !isMultiPost);
        }
    }
