    public class FragmentAViewModel : MvxViewModel
    {
        public ISharedShoppingCart SharedContext { get; }
    
        public FragmentAViewModel(ISharedContext sharedContext)
        {
            SharedContext = sharedContext;
        }
    }
    
    public class ActivityViewModel : MvxViewModel
    {
        public ISharedShoppingCart SharedContext { get; }
    
        public ActivityViewModel(ISharedContext sharedContext)
        {
            SharedContext = sharedContext;
        }
    }
