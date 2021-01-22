public sealed class serviceConfigDataRemote : MarshalByRefObject
	{
		private bool myConnectedFlag;
		private bool mySendingFlag;
		private bool myUpdateFlag;
		private string myClientConfiguration;
		static serviceConfigDataRemote instance;
		static serviceConfigDataRemote()
		{
		}
		public serviceConfigDataRemote()
		{
			myConnectedFlag = false;
			mySendingFlag = false;
			myUpdateFlag = false;
			myClientConfiguration = "";
		}
		public static serviceConfigDataRemote Instance
		{
			get
			{
				if (instance == null)
				{
					lock (new Object())
					{
						if (instance == null)
						{
							instance = new serviceConfigDataRemote();
						}
						return instance;
					}
				}
				return instance;
			}
		}
		public override object InitializeLifetimeService()
		{
			return (null);
		}
		public bool Connected
		{
			get { return myConnectedFlag; }
			set { myConnectedFlag = value; }
		}
		public bool Sending
		{
			get { return mySendingFlag; }
			set { mySendingFlag = value; }
		}
		public bool CheckForUpdates
		{
			get { return myUpdateFlag; }
			set { myUpdateFlag = value; }
		}
		public string ClientConfiguration
		{
			get { return myClientConfiguration; }
			set { myClientConfiguration = value; }
		}
	}
