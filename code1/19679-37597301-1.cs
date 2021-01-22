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
        static T VisualParent<T>(DependencyObject node) where T : class
        {
            if (node == null)
                throw new InvalidOperationException("Could not locate a parent " + typeof(T).Name);
            var target = node as T;
            if (target != null)
                return target;
            return VisualParent<T>(VisualTreeHelper.GetParent(node));
        }
    }
