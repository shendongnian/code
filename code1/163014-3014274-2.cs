    public class MyClass
    {
        private readonly IRequestContext reqCtx;
        public MyClass(IRequestContext reqCtx)
        {
            if (reqCtx == null)
            {
                throw new ArgumentNullException("reqCtx");
            }
            this.reqCtx = reqCtx;
        }
        // Implement using this.reqCtx...
    }
