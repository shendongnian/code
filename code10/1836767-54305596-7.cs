c#
	@functions{
		public string Username { get; set; }
		public string url = "/home";
		public async Task AuthAsync()
		{
			var ticket=await this.auth.AuthenticateAsync(Username);
			// Attach the parameter to the url
			urihelper.NavigateTo(url + "/" + Username); 
		}
	}
Hope this helps...
