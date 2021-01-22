    	public static void Main(string[] args)
        {
             
		    var webService = new ServiceReference1.MyWebService();
            ....
           webService.Open();
			
            
			using (OperationContextScope scope = new OperationContextScope((IContextChannel)webService.InnerChannel))
            {
               
				var myObjRequest = GetMyObjRequest();
                
				MessageHeaders messageHeadersElement = OperationContext.Current.OutgoingMessageHeaders;
                messageHeadersElement.Add(SecurityHeader("UserName", "Password"))
                
            
                 var res = webService.MyServe(myObjRequest);
                Console.WriteLine(res.ToString());
            }
		}
