    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System;
    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;
    using System.Text;
	
    namespace YourSpaceName
    {
        [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
        public class YourClassName
        {
			[OperationContract]
			[WebInvoke(Method = "POST", UriTemplate = "YourMethodName({id})", BodyStyle = WebMessageBodyStyle.Bare)]
			public Stream YourMethodName(Stream input, string id)
			{
				WebOperationContext ctx = WebOperationContext.Current;
				ctx.OutgoingResponse.Headers.Add("Content-Type", "application/json");
			
				string response = $@"{{""status"": ""failure"", ""message"": ""Please specify the Id of the vehicle requisition to retrieve."", ""d"":null}}";
				try
				{
					string response = (new StreamReader(input)).ReadToEnd();
				}
				catch (Exception ecp)
				{
					response = $@"{{""status"": ""failure"", ""message"": ""{ecp.Message}"", ""d"":null}}";
				}
			
				return new MemoryStream(Encoding.UTF8.GetBytes(response));
			}
		}
    }
