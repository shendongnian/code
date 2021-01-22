    public class TitleModule : IHttpModule
    {
        public void Dispose()
        {
        }
    
        private static Regex regex = new Regex(@"(?<=<title>)[\w\s\r\n]*?(?=</title)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private StreamWatcher _watcher;
        public void Init(HttpApplication context)
        {
            context.BeginRequest += (o, e) => 
            {
                _watcher = new StreamWatcher(context.Response.Filter);
                context.Response.Filter = _watcher;
            };
    
    
            context.EndRequest += (o, e) =>
            {
                string value = _watcher.ToString();
                Trace.WriteLine(regex.Match(value).Value.Trim());
            };
        }
    }
