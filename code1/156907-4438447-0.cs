        /// <summary>
    	/// Interface for communicating with twitter.com.
    	/// </summary>
    	[ServiceContract]
    	public interface ITwitterClient
    	{
            [OperationContract]
            [WebGet(UriTemplate = "statuses/user_timeline/{twitterName}.xml?count={numberOfTweets}",
                BodyStyle = WebMessageBodyStyle.Bare,
                RequestFormat = WebMessageFormat.Xml,
                ResponseFormat = WebMessageFormat.Xml)]
            Statuses PublicTimeline(string twitterName, int numberOfTweets);
        }
