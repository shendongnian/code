	public class AuthenticationResult
	{
		#region Fields/Properties
		public bool Success { get; internal set; }
		public string Message { get; internal set; }
		public IDictionary<string,string> Errors { get; internal set; }
		#endregion
		#region Constructors
		public AuthenticationResult( bool success, string message ) : this( success, message, null )
		{
		}
		public AuthenticationResult( bool success, string message, IDictionary<string, string> errors )
		{
			Success = success;
			Message = message;
			Errors = errors ?? new Dictionary<string, string>();
		}
		#endregion
	}
