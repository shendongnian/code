    public class WebSessionScopeAccessor : IScopeAccessor
    {
        public void Dispose()
        {
            var scope = PerWebSessionLifestyleModule.YieldScope();
            if (scope != null)
            {
                scope.Dispose();
            }
        }
        public ILifetimeScope GetScope(CreationContext context)
        {
            return PerWebSessionLifestyleModule.GetScope();
        }
    }
