    public class RestService: IHttpHandler
    {
        private readonly bool _isReusable = true;
        protected HttpContext _context;
        private IDictionary<HttpVerb, MethodInfo> _methods;
        public void ProcessRequest(HttpContext context)
        {
            _context = context;
            HttpVerb verb = (HttpVerb)Enum.Parse(typeof (HttpVerb), context.Request.HttpMethod);
            MethodInfo method = Methods[verb];
            method.Invoke(this, null);
        }
        private IDictionary<HttpVerb, MethodInfo> Methods
        {
            get
            {
                if(_methods == null)
                {
                     _methods = new Dictionary<HttpVerb, MethodInfo>();
                    BuildMethodsMap();
                }
                return _methods;
            }
        }
        private void BuildMethodsMap()
        {
            Type serviceType = this.GetType();
            MethodInfo[] methods = serviceType.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (MethodInfo info in methods)
            {
                RestMethodAttribute[] attribs =
                    info.GetCustomAttributes(typeof(RestMethodAttribute), false) as RestMethodAttribute[];
                if(attribs == null || attribs.Length == 0)
                    continue;
                HttpVerb verb = attribs[0].Verb;
                Methods.Add(verb, info);
            }
        }
        public bool IsReusable
        {
            get { return _isReusable; }
        }
    }
