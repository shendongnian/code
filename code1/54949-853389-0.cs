        [WebServiceBinding()]
		public class WebService
		: System.Web.Services.Protocols.SoapHttpClientProtocol
		{
			[SoapTrace]
			public object[] MethodTest(string param1, string param2)
			{
				object[] result = this.Invoke("MethodTest", new object[] { param1, param2 });
				return (object[])result[0];
			}
		}
