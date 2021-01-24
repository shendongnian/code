    kernel.Bind<ResolveMe>()
         .ToSelf()
         .WithConstructorArgument<IEnumerable<IDispatchFilter>>(bindDecoyDispatchFilters);
    private IList<IDispatchFilter> bindDecoyDispatchFilters(IContext context)
    {
        // Contract.Assert(1 == 0); // .. .ensure the method is called during resolution!
        context.Kernel.Bind<IDispatchFilter>().To<WindowsXpFilter>();
        return context.Kernel.GetAll<IDispatchFilter>().ToList();
    }
