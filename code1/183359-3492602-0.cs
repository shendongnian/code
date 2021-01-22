	public class MyRequest
	{
		public MyRequest(string methodName, params object[] parameters)
		{
			this.MethodName = methodName;
			this.Parameters = parameters;
		}
		public string MethodName { get; set; }
		public object[] Parameters { get; set; }
		public object[] Response {get; set;}
	}
	public class MyProxy : dotNetGeneratedServiceProxy
	{
		List<MyRequest> Requests { get; set; }
		public void QueueMethod1(int param1, string param2)
		{
			Requests.Add(new MyRequest("Method1", param1, param2));
		}
		public void QueueMethod2(string param1)
		{
			Requests.Add(new MyRequest("Method2", param1));
		}
		public void RunAllRequests()
		{
			foreach (var request in Requests)
			{
				var result = this.Invoke(request.MethodName, request.Parameters);
			}
		}
	}
