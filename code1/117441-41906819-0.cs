		public class Url
		{
			public string LocalUrl { get; }
			public Url(string localUrl)
			{
				LocalUrl = localUrl;
			}
			public override string ToString()
			{
				return LocalUrl;
			}
		}
		public abstract class Controller
		{
			public Url RootAction => new Url(GetUrl());
			protected abstract string Root { get; }
			public Url BuildAction(string actionName)
			{
				var localUrl = GetUrl() + "/" + actionName;
				return new Url(localUrl);
			}
			private string GetUrl()
			{
				if (Root == "")
				{
					return "";
				}
				return "/" + Root;
			}
			public override string ToString()
			{
				return GetUrl();
			}
		}
