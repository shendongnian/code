    public sealed class UserAction
    {
        public static UserAction SendMessage = new UserAction(3);
        public static UserAction PhonedFriend = new UserAction(4);
        public static UserAction LikedPost = new UserAction(1);
        public static UserAction CommentedOnPost = new UserAction(2);
        private UserAction(int tokens) => Tokens = tokens;
        public int Tokens { get; }
    }
