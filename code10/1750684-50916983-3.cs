    public class CustomResultWrapperHandler : ResultWrapperHandler, ITransientDependency
    {
          
        //...
        protected override void WrapResultIfNeeded(HttpRequestMessage request, HttpResponseMessage response)
        {
            
            //...
    
            base.WrapResultIfNeeded(request, response);
        }
    }
