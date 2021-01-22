    public class SessionScopeAccessor : IScopeAccessor
    {
        private const string Key = "castle.per-web-session-lifestyle-cache";
        public void Dispose()
        {
            var context = HttpContext.Current;
            if (context == null || context.Session == null)
                return;
            SessionEnd(context.Session);
        }
        public ILifetimeScope GetScope(CreationContext context)
        {
            var current = HttpContext.Current;
            if (current == null)
            {
                throw new InvalidOperationException("HttpContext.Current is null. PerWebSessionLifestyle can only be used in ASP.Net");
            }
            var lifetimeScope = (ILifetimeScope)current.Session[Key];
            if (lifetimeScope == null)
            {
                lifetimeScope = new DefaultLifetimeScope(new ScopeCache());
                current.Session[Key] = lifetimeScope;
                return lifetimeScope;
            }
            return lifetimeScope;
        }
        // static helper - should be called by Global.asax.cs.Session_End
        public static void SessionEnd(HttpSessionState session)
        {
            var scope = (ILifetimeScope)session[Key];
            if (scope != null)
            {
                scope.Dispose();
                session.Remove(Key);
            }
        }
    }
