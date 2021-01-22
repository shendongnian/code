	///<summary>The exception thrown because of ...</summary>
	[Serializable]
	public class MyException : Exception {
		///<summary>Creates a MyException with the default message.</summary>
		public MyException () : this("An error occurred") { }
		///<summary>Creates a MyException with the given message.</summary>
		public MyException (string message) : base(message) { }
		///<summary>Creates a MyException with the given message and inner exception.</summary>
		public MyException (string message, Exception inner) : base(message, inner) { }
		///<summary>Deserializes a MyException .</summary>
		protected MyException (SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
