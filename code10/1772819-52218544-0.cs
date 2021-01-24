    public class RazorPerformanceDiagnosticListener
    {
        private readonly IDictionary<string, TemplatePerformanceHolder> _timers = new ConcurrentDictionary<string, TemplatePerformanceHolder>();
        
        [DiagnosticName("Microsoft.AspNetCore.Mvc.Razor.BeginInstrumentationContext")]
        public virtual void OnBeginInstrumentationContext(HttpContext httpContext, string path, int position, int length, bool isLiteral)
        {
            if (_timers.ContainsKey(path))
            {
                _timers[path].ContextDepth++;
            }
            else
            {
                _timers[path] = new TemplatePerformanceHolder(){ContextDepth = 1, Stopwatch = Stopwatch.StartNew() };
            }
        }
        [DiagnosticName("Microsoft.AspNetCore.Mvc.Razor.EndInstrumentationContext")]
        public virtual void OnEndInstrumentationContext(HttpContext httpContext, string path)
        {
            _timers[path].ContextDepth--;
            if (_timers[path].ContextDepth == 0)
            {
                _timers[path].Stopwatch.Stop();
                //log _timers[path].Stopwatch.Elapsed
                _timers.Remove(path);
            }
        }
    }
    public class TemplatePerformanceHolder
    {
        public Stopwatch Stopwatch;
        public int ContextDepth;
    }
