    public sealed class User
    {
        private readonly HashSet<UserAction> _doneActions;
        public User() => _doneActions = new HashSet<UserAction>();
        public ReqRewardResult AddAction(UserAction action) => _doneActions.Add(action) ? ReqRewardResult.ReqSuccess : ReqRewardResult.RewardAlreadyGiven;
        public int EarnedTokens => _doneActions.Sum(ua => ua.Tokens);
    }
