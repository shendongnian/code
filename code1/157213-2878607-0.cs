    public class ViewAttribute : ExportAttribute
    {    
        public object TargetRegion { get; set; }
        public Type ViewModel { get; set; }
        public Type Module { get; set; }
    
        public ViewAttribute(Type decoratedClassType)
            : base(typeof(UserControl))
        {
            Module = decoratedClassType
        }
    }
    
    [View(typeof(HomeView))]
    HomeView MyHomeView { get; set; }
