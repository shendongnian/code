    class Tweet
    {
        public Tweet(string message, bool isRetweet)
        {
            Message = message;
            IsRetweet = isRetweet;
        }
        string Message { get; private set; }
        bool IsRetweet { get; private set; }
    }
