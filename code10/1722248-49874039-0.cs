    public class ODataFetchActivity<TResult> : ODataActivity<TResult>
    {
        public string Query { get; set; }
    
        Func<TResult> work;
    
        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            work = () => Api.Get<TResult>(Query).Result;
            context.UserState = work;
            return work.BeginInvoke(callback, state);
        }
    
        protected override TResult EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            TResult response = work.EndInvoke(result);
            Result.Set(context, response);
            return response;
        }
    }
