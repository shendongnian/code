    public class Response<T> where T:BusinessObject
	{
		public Response(T oldOriginalValue, T newValue)
		{
		}
		/// <summary>
		/// List of Validation Messages
		/// </summary>
		public List<ValidationMessage> ValidationMessages { get; set; }
		/// <summary>
		/// Object passed into the CRUD method
		/// </summary>
		public T OldValue { get; private set; }
		/// <summary>
		/// Object passed back from the CRUD method, with values of identity fields, etc populated
		/// </summary>
		public T NewValue { get; private set; }
		/// <summary>
		/// Was the operation successful
		/// </summary>
		public bool Success { get; set; }
	}
	public class ValidationMessage
	{
		/// <summary>
		/// Property causing validation message (i.e. FirstName)
		/// </summary>
		string Property { get; set; }
		/// <summary>
		/// Validation Message text
		/// </summary>
		string Message { get; set; }
	}
