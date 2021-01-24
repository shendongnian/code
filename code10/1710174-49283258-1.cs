        static string[] _scopes = { ClassroomService.Scope.ClassroomCoursesReadonly };
		static string _applicationName = "DiBS Google Classroom API";
		private static readonly IAuthorizationCodeFlow flow =
			new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
			{
				ClientSecrets = new ClientSecrets
				{
					ClientId = ConfigurationManager.AppSettings["GoogleClassroomClientID"],
					ClientSecret = ConfigurationManager.AppSettings["GoogleClassroomSecret"]
				},
				Scopes = _scopes
			});
		
		[Route("google/getcourses")]
		[HttpGet] 
		public void GetCourses()
		{
			try
			{
				LogInfo($"Google GetCourses: Start");
				UserCredential creds = AuthorizeGoogleUser();
				if (creds == null)
					throw new Exception("Invalid Google User");
				
				// Create Classroom API service.
				var service = new ClassroomService(new BaseClientService.Initializer()
				{
					HttpClientInitializer = creds,
					ApplicationName = _applicationName,
				});
				// Define request parameters.
				CoursesResource.ListRequest request = service.Courses.List();
				request.PageSize = 10;
				// List courses.
				ListCoursesResponse response = request.Execute();
				if (response.Courses != null && response.Courses.Count > 0)
				{
					foreach (var course in response.Courses)
					{
						LogInfo($"Google GetCourses: {course.Name}, {course.Id}");
					}
				}
				else
				{
					LogInfo("Google GetCourses: No courses found.");
				}
			}
			catch (Exception ex)
			{
				HandleError(null, ex);
			}
		}
		private UserCredential AuthorizeGoogleUser()
		{
			try
			{
				string GAT = HttpContext.Current.Request.Headers["GAT"];
				string GRT = HttpContext.Current.Request.Headers["GRT"];
				if (GAT == null || GRT == null)
					return null;
				var token = new TokenResponse
				{
					AccessToken = GAT,
					RefreshToken = GRT
				};
				var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
				{
					ClientSecrets = new ClientSecrets
					{
						ClientId = ConfigurationManager.AppSettings["GoogleClassroomClientID"],
						ClientSecret = ConfigurationManager.AppSettings["GoogleClassroomSecret"]
					},
					Scopes = _scopes,
					DataStore = new FileDataStore("DiBS-Web.Google.Classroom.Api.Store")
				});
				UserCredential credential = new UserCredential(flow, "me", token);
				return credential;
			}
			catch
			{
				return null;
			}
		}
