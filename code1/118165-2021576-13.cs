    public ViewRegistry : IViewRegistry
    {
         public static List<Func<object>> ViewFactories
         {
               get { return _viewFactories; }
         }
         static List<Func<object>> _viewFactories = new List<Func<object>>();
         public void RegisterMainView(Func<object> viewFactory)
         {
              _viewFactories.Add(viewFactory);
         }
    }
