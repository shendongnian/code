    public class AmpViewLocationExpander : IViewLocationExpander
    {
        private const string ValueKey = "ampmode";
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // magic utility method that determines whether this is within an AMP context
            var isAmp = context.ActionContext.HttpContext.IsAmp();
            // persist the value on the context to allow the cache to consider this
            context.Values[ValueKey] = isAmp.ToString();
        }
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            // when in AMP mode
            if (context.Values.TryGetValue(ValueKey, out var isAmpValue) && isAmpValue == "True")
            {
                return ExpandAmpViewLocations(viewLocations);
            }
            // otherwise fall back to default locations
            return viewLocations;
        }
        private IEnumerable<string> ExpandAmpViewLocations(IEnumerable<string> viewLocations)
        {
            foreach (var location in viewLocations)
            {
                // yield the AMP version first
                yield return location.Replace("{0}", "{0}.amp");
                // then yield the normal version as a fallback
                yield return location;
            }
        }
    }
