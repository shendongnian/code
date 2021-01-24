    class Program
	{
		static void Main(string[] args)
		{
			var p = new Program();
			p.Run();
		}
		private async void Run()
		{
			await LoadCampaignTempleteJSONAsync();
		}
		private static Task LoadCampaignTempleteJSONAsync()
		{
            //Put breakpoint here!
			throw new NotImplementedException();
		}
	}
