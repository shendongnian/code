    using Prism.Mvvm;
    using Prism.Regions;
    
    public MyBindableBase : BindableBase, IRegionMemberLifetime
    {
        public virtual bool KeepAlive => false;
    ...
    }
