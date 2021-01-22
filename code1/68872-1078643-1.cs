    public class RequestOrSession
    {
        public object this[string key]
        {
            get
            {
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    throw new InvalidOperationException("Where's the HttpContext?");
                }
                // if the same key exists in Request and Session
                // then Request will currently be given priority
                return context.Request[key] ?? context.Session[key];
            }
        }
    }
