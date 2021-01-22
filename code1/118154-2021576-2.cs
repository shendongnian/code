    public MyModule : IModule
    {
         IViewRegistry _registry;
         public MyModule(IViewRegistry registry)
         {
              _registry = registry;
         }
    
         public void Initialize()
         {
              _registry.RegisterMainView(() =>
              {
                   var vm = new MyViewModel();
                   var view = new MyView();
                   var view.DataContext = vm;
                   return view;
              });
         }
    }
