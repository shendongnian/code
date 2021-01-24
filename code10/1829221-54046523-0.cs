    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        base.OnCreateView(inflater, container, savedInstanceState);
        var view = this.BindingInflate(Resource.Layout.HomeView, null);
        _carouselView = view.FindViewById<CarouselView>(Resource.Id.carouselView);
        var recyclerView = view.FindViewById<MvxRecyclerView>(Resource.Id.product_recycler);
        _carouselView.PageCount = ViewModel.Carousels.Count;
        _carouselView.SetImageListener(this);
        if (recyclerView != null)
        {
            recyclerView.HasFixedSize = true;
            var layoutManager = new GridLayoutManager(Activity, 2, LinearLayoutManager.Vertical, false);
            recyclerView.SetLayoutManager(layoutManager);
        }
        return view;
    }
