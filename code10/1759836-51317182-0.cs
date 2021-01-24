	public class Request<T1, T2>
	{
        // Common data needed by every GetAsync(), no matter what it returns:
		public string user;
		public string token;
		public Request(string user, string token)
		{
			this.user = user;
			this.token = token;
		}
	}
	public class Request<T1, T2, T3> : Request<T1, T2>
	{
		public Request(string user, string token) : base(user, token) { }
	}
