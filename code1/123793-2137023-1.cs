    public class Twitterer : MyTask
    {
        private string _tweet;
        public Twitterer(string tweet)
        {
            _tweet = tweet;
        }
        public override DoWork()
        {
            TwitterApi api = new TwitterApi(); // whatever
            api.PostTweet(tweet);
        }
    }
