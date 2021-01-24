    public interface INewViewLocationResultProvider
    {
        bool UseCachedView { get; set; }
        ViewLocationResult GetNewerVersion(string viewName, NancyContext context);
        void UpdateCachedView(IDictionary<string, ViewLocationResult> replacements);
    }
 2. Make a new ViewLocationResultProvider
public class ConcurrentNewViewLocationResultProvider : INewViewLocationResultProvider
    {
        private Dictionary<string, ViewLocationResult> _cachedViewLocationResults;
        private readonly object _cacheLock = new object();
        public bool UseCachedView { get; set; }
        public ConcurrentNewViewLocationResultProvider()
        {
            lock (_cacheLock)
            {
                if(_cachedViewLocationResults == null)_cachedViewLocationResults = new Dictionary<string, ViewLocationResult>();
            }
        }
        public ViewLocationResult GetNewerVersion(string viewName, NancyContext context)
        {
            if (UseCachedView)
            {
                if (Monitor.TryEnter(_cacheLock, TimeSpan.FromMilliseconds(20)))
                {
                    try
                    {
                        if (_cachedViewLocationResults != null && _cachedViewLocationResults.ContainsKey(viewName))
                        {
                            return _cachedViewLocationResults[viewName];
                        }
                    }
                    finally
                    {
                        Monitor.Exit(_cacheLock);
                    }
                }
            }
            return null;
        }
        public void UpdateCachedView(IDictionary<string, ViewLocationResult> replacements)
        {
            lock (_cacheLock)
            {
                if(_cachedViewLocationResults == null)_cachedViewLocationResults = new Dictionary<string, ViewLocationResult>();
                foreach (var replace in replacements)
                {
                    if (_cachedViewLocationResults.ContainsKey(replace.Key))
                    {
                        _cachedViewLocationResults[replace.Key] = replace.Value;
                    }
                    else
                    {
                        _cachedViewLocationResults.Add(replace.Key,replace.Value);
                    }                   
                }
            }
        }
    }
 3. In your Bootstrapper,register the new ViewLocationResultProvider with tinyIoc or equivalent
container.Register<INewViewLocationResultProvider, ConcurrentNewViewLocationResultProvider>().AsSingleton();
 4. Make a derived class from ViewLocationResult
    public class OneTimeUsedViewLocationResult : ViewLocationResult
    {
        private bool _used = false;
        public OneTimeUsedViewLocationResult(string location, string name, string extension, Func<TextReader> contents)
            : base(location, name, extension, contents)
        {
        }
        public override bool IsStale()
        {
            if (_used) return false;
            _used = true;
            return true;
        }
    }
 5. And a new IViewLocator:
public class CachedViewLocator : IViewLocator
    {
        private readonly INewViewLocationResultProvider _newVersion;
        private readonly DefaultViewLocator _fallbackViewLocator;
        public CachedViewLocator(IViewLocationProvider viewLocationProvider, IEnumerable<IViewEngine> viewEngines, INewViewLocationResultProvider newVersion)
        {
            _fallbackViewLocator = new DefaultViewLocator(viewLocationProvider, viewEngines);
            _newVersion = newVersion;
        }
        public ViewLocationResult LocateView(string viewName, NancyContext context)
        {
            if (_newVersion.UseCachedView)
            {
                var result = _newVersion.GetNewerVersion(viewName, context);
                if (result != null) return result;
            }
            return _fallbackViewLocator.LocateView(viewName, context);
        }
        public IEnumerable<ViewLocationResult> GetAllCurrentlyDiscoveredViews()
        {
            return _fallbackViewLocator.GetAllCurrentlyDiscoveredViews();
        }
    }
}
 6. Tell nancy about the new ViewLocator
        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides
                (
                    nic =>
                    {
                        nic.ViewLocationProvider = typeof(ResourceViewLocationProvider);//use this or your equivalent
                        nic.ViewLocator = typeof(CachedViewLocator);
                    }
                );
            }            
        }
 7. Then you can update it through a API like this:
public class YourModule : NancyModule
{
    public YourModule(INewViewLocationResultProvider provider)
    {
       Get["/yourupdateinterface"] = param =>
       {
          if(!provider.UseCachedView) return HttpStatusCode.BadRequest;//in case you turn off the hot update
          //you can serialize your OneTimeUsedViewLocationResult with Newtonsoft.Json and store those views in any database, like mysql, redis, and load them here
          //data mock up
          TextReader tr = new StringReader(Resources.TextMain);                
          var vlr = new OneTimeUsedViewLocationResult("","index","cshtml",()=>tr);
          var dir = new Dictionary<string, ViewLocationResult> {{"index",vlr}};
          //mock up ends
          provider.UpdateCachedView(dir);
          return HttpStatusCode.OK;
       }
    }
}
Note: Those code above doesn't solve the manually map all the Location,Name,Extension for the ViewLocationResult thing menthions in my question, but since I endup build a view editor for my colleges to upload their views, I don't need to solve it anymore. 
