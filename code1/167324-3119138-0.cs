    public void Init(HttpApplication context)
        {
            
            context.PostRequestHandlerExecute += (sender, e) =>
            {
                Page p = context.Context.Handler as Page;
                if (p != null)
                {
                ///Code here    
                }
            };
        }
