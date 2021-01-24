    public class Result<TResultType>
   	{
   		public int? ErrorId { get; set; } // Todo: Use it!!!
   		public bool Success { get; set; }
   		public ResponseErrorType ErrorType { get; set; }
   		public string Message { get; set; }
   		public TResultType Data { get; set; }
    }
