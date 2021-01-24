	public class Response<T>
	{
		public int Code { get; set; }
		public string Message { get; set; }
		public T Result { get; set; }
		public DateTime ResponseDateTime { get; set; }
	}
	
	public class Detail
	{
		public int Id { get; set; }
		public string DetailOne { get; set; }
		public string DetailTwo { get; set; }
	}
