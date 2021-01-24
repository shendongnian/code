    class	PublishAnnouncement	{
	private	static	readonly	object	syncLockForTwitter	=	new	object();
	private	static	readonly	object	syncLockForFacebook	=	new	object();
	//This	function	is	callled	upon	in	many	parts	of	the	program	and	acts	as	a	general	publisher
	public	static	void	PostAnnoucment(string	message,	string	TwAccountKey,	string	FbAccountKey,	string[]	JourneyRefID,	double	latness,	MainWindow	mainWindow)	{
		//First	it	is	published	to	facebook
		BackgroundWorker	FacebookWorker	=	new	BackgroundWorker();
		FacebookWorker.DoWork	+=	(obj,	e)	=>	FacebookDoWork(message,	FbAccountKey);
		FacebookWorker.RunWorkerAsync();
		//Then	it	is	published	to	twitter	-	This	is	where	it	appears	to	fail
		BackgroundWorker	TwitterWorker	=	new	BackgroundWorker();
		TwitterWorker.DoWork	+=	(obj,	e)	=>	TwitterDoWork(message,	TwAccountKey,	JourneyRefID,	latness,	mainWindow,	0);
		TwitterWorker.RunWorkerAsync();
	}
	private	static	void	FacebookDoWork(string	message,	string	FbAccountKey)	{
		lock(syncLockForFacebook)	{
		//STAGE	1	-	Facebook
		//First	the	program	will	attempt	to	post	a	Facebook	post.
			try	{
				//If	it	is	to	be	posted	by	one	of	the	additional	Facebook	Pages	and	
				//not	by	the	default	page.
				var	client	=	new	RestClient("https://graph.facebook.com/v3.0/");
				var	request	=	new	RestRequest("{pageId}/feed",	Method.POST);
				request.AddParameter("message",	message);	//	adds	to	POST	or	URL	querystring	based	on	Method
				request.AddParameter("access_token",	Properties.Settings.Default.FBPageAccessToken);
				request.AddUrlSegment("pageId",	Properties.Settings.Default.FBPageID);	//	replaces	matching	token	in	request.Resource
				IRestResponse	response	=	client.Execute(request);
				if	(response.IsSuccessful	==	false)	{
					Console.WriteLine(response.Content);
					Console.WriteLine("");
				}
			}	catch	(Exception	ex)	{
				Console.WriteLine(ex.ToString());
			}
		}
	}
	private	static	void	TwitterDoWork(string	message,	string	TwAccountKey,	string[]	JourneyRefID,	double	latness,	MainWindow	mainWindow,	int	Attempts)	{
		lock(syncLockForTwitter)	{
		//STAGE	2	-	Twitter
		//Once	a	Facebook	post	has/has	not	been	posted	the	program	will	attempt	to	send	a	tweet.
			try	{
				Auth.SetUserCredentials(Properties.Settings.Default.TwConsumerKey,	Properties.Settings.Default.TwConsumerSecret,	Properties.Settings.Default.TwUserAccessToken,	Properties.Settings.Default.TwUserAccessSecret);
				var	tweet	=	Tweet.PublishTweet(message);
				foreach(var	ID	in	JourneyRefID)
									AddTweetID(tweet.Id,	ID,	latness,	mainWindow);
			}	catch	(Exception	ex)	{
				foreach(var	ID	in	JourneyRefID)
									AddTweetID(0,	ID,	latness,	mainWindow);
				Console.WriteLine(ex.Message);
			}
		}
	}
}
