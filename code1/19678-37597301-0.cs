    public sealed class MyExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider) =>
            new MyWrapper(ResolveRootObject(serviceProvider));
        object ResolveRootObject(IServiceProvider serviceProvider) => 
             GetService<IRootObjectProvider>(serviceProvider).RootObject;
    }
    class MyWrapper
    {
        object _rootObject;
        Window OwnerWindow() => WindowFromRootObject(_rootObject);
        static Window WindowFromRootObject(object root) =>
            (root as Window) ?? VisualParent<Window>((DependencyObject)root);
        static T VisualParent<T>(DependencyObject level) where T : class
        {
            if (level == null)
                throw new InvalidOperationException("Could not locate a parent " + typeof(T).Name);
            var target = level as T;
            if (target != null)
                return target;
            return VisualParent<T>(VisualTreeHelper.GetParent(level));
        }
    }
