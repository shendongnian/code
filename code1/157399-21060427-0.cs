			string ckey = "consumerkey";
			string csecret = "consumersecret";
			
			var auth = new PinAuthorizer()
			{
				Credentials = new InMemoryCredentials
				{
					ConsumerKey = ckey,
					ConsumerSecret = csecret
				},
				GoToTwitterAuthorization = pageLink => Process.Start(pageLink),
				GetPin = () =>
				{
					Console.WriteLine(
						"\nAfter authorizing this application, Twitter " +
						"will give you a 7-digit PIN Number.\n");
					Console.Write("Enter the PIN number here: ");
					return Console.ReadLine();
				}
			};
			auth.Authorize();
			var twitterCtx = new TwitterContext(auth);
			twitterCtx.UpdateStatus("This status has been created from a C# console app!");
		}`
