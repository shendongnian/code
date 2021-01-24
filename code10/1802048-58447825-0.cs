            public class DialogflowManager {
   		    private string _userID;
   		    private string _webRootPath;
   		    private string _contentRootPath;
   		    private string _projectId;
   		    private SessionsClient _sessionsClient;
   		    private SessionName _sessionName;
   		    public DialogflowManager(string userID, string webRootPath, string contentRootPath, string projectId) {
   		        _userID = userID;
   		        _webRootPath = webRootPath;
   		        _contentRootPath = contentRootPath;
   		        _projectId = projectId;
   		        SetEnvironmentVariable();
   		    }
   		    private void SetEnvironmentVariable() {
   		        try {
   		            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", _contentRootPath + "\\Keys\\{THE_DOWNLOADED_JSON_FILE_HERE}.json");
   		        } catch (ArgumentNullException) {
   		            throw;
   		        } catch (ArgumentException) {
   		            throw;
   		        } catch (SecurityException) {
   		            throw;
   		        }
   		    }
   		    private async Task CreateSession() {
   		        // Create client
   		        _sessionsClient = await SessionsClient.CreateAsync();
   		        // Initialize request argument(s)
   		        _sessionName = new SessionName(_projectId, _userID);
   		    }
   		    public async Task < QueryResult > CheckIntent(string userInput, string LanguageCode = "en") {
   		        await CreateSession();
   		        QueryInput queryInput = new QueryInput();
   		        var queryText = new TextInput();
   		        queryText.Text = userInput;
   		        queryText.LanguageCode = LanguageCode;
   		        queryInput.Text = queryText;
   		        // Make the request
   		        DetectIntentResponse response = await _sessionsClient.DetectIntentAsync(_sessionName, queryInput);
   		        return response.QueryResult;
   		    }
   		}
