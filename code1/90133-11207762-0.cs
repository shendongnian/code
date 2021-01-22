    using Nancy;
    using Nancy.ModelBinding;
    
    public class Api : NancyModule
            {
                public Api()
                {
                    Get["/api/order/create"] = x => 
                    { 
                        var order = this.Bind<Order>(); //xml/json negotiated based on content header
        
                        var result = ... // Do stuff here
        
                        return Response.AsJson(result); 
                    };
                }       
            }
