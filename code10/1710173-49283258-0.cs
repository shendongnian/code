        public async Task<UserCredential> GetUserCredential()
		{
			try
			{
				UserCredential credential;
				
				credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
						   new ClientSecrets
						   {
							   ClientId = ConfigurationManager.AppSettings["GoogleClassroomClientID"],
							   ClientSecret = ConfigurationManager.AppSettings["GoogleClassroomSecret"]
						   }, _scopes, "user", CancellationToken.None, new FileDataStore("Web.Google.Classroom.Api.Store"));
				return credential;
			}
			catch (Exception ex)
			{
				HandleError(ex);
				return null;
			}
		}
