    [MvxFragmentPresentation(fragmentHostViewType: typeof(SplitDetailView), fragmentContentId: Resource.Id.tabs_frame, addToBackStack: true)]
    [Register(nameof(TabsRootBView))]
    public class TabsRootBView : MvxFragment<TabsRootBViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.TabsRootBView, null);
            return view;
        }
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            if (savedInstanceState == null)
            {
                ViewModel.ShowInitialViewModelsCommand.Execute();
            }
        }
    }
