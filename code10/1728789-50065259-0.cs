I figured one way to inject into the construtor of PageModel using Simple Injector:
    
    public class SimpleInjectorPageModelActivatorProvider : IPageModelActivatorProvider
    {
        private readonly Action<PageContext, object> _disposer = new Action<PageContext, object>(DisposePage);
        private Container Container { get; }
        public SimpleInjectorPageModelActivatorProvider(Container container)
        {
            this.Container = container;
        }
        /// <inheritdoc />
        public virtual Func<PageContext, object> CreateActivator(CompiledPageActionDescriptor actionDescriptor)
        {
            if (actionDescriptor == null)
                throw new ArgumentNullException(nameof (actionDescriptor));
            TypeInfo modelTypeInfo = actionDescriptor.ModelTypeInfo;
            Type instanceType = modelTypeInfo != null ? modelTypeInfo.AsType() : (Type) null;
            if (instanceType == (Type) null)
                throw new ArgumentException("ModelTypeInfo of " + nameof (actionDescriptor) + "Cannot be null.");
            return (Func<PageContext, object>) (context => Container.GetInstance(instanceType));
        }
        public virtual Action<PageContext, object> CreateReleaser(CompiledPageActionDescriptor actionDescriptor)
        {
            if (actionDescriptor == null)
                throw new ArgumentNullException(nameof (actionDescriptor));
            if (typeof (IDisposable).GetTypeInfo().IsAssignableFrom(actionDescriptor.ModelTypeInfo))
                return this._disposer;
            return (Action<PageContext, object>) null;
        }
        private static void Dispose(PageContext context, object page)
        {
            if (context == null)
                throw new ArgumentNullException(nameof (context));
            if (page == null)
                throw new ArgumentNullException(nameof (page));
            ((IDisposable) page).Dispose();
        }
        public static void DisposePage(PageContext context, object page)
        {
            if (context == null)
                throw new ArgumentNullException(nameof (context));
            if (page == null)
                throw new ArgumentNullException(nameof (page));
            ((IDisposable) page).Dispose();
        }
    }
