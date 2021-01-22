    interface IViewFactory<TView, TDomain>
    {
       TView Create(TDomain domain);
    }
    class ViewFactoryA : IViewFactory<ViewA, DomainA>
    {
       ...
    }
    class ViewFactoryB : IViewFactory<ViewB, DomainB>
    {
       ...
    }
