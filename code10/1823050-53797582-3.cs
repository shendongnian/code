    internal static class WindowPaneExtensions
    {
        private static readonly Func<WindowPane, Type, object> WindowPaneGetService = CreateWindowPaneGetService();
        public static bool With<T>(this WindowPane pane, out T service)
        {
            service = (T)WindowPaneGetService(pane, GetServiceQueryType<T>());
            return service != null;
        }
        private static Func<WindowPane, Type, object> CreateWindowPaneGetService()
        {
            var method = typeof(WindowPane).GetMethod("GetService", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(Type) }, null);
            var del = (Func<WindowPane, Type, object>)method.CreateDelegate(typeof(Func<WindowPane, Type, object>));
            return del;
        }
    }
