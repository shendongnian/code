    public async void OnAnimationEnd(Animation animation)
    {
        await Task.Run(() => Dodo()).ConfigureAwait(false);
        RunOnUIThread(AssignDodoAdapter());
    }
    
    void Dodo()
    {
        AdRequest adRequest = new 
     AdRequest.Builder().AddTestDevice(AdRequest.DeviceIdEmulator).Build();
        adView.LoadAd(adRequest);
        AccessFiles();
        adapter = new MyArryAdapter(this, Resource.Layout.AdaptView,  CustomView.multipleData.ToList());
    }
    
    void AssignDodoAdapter()
    {
        listView.Adapter = adapter;
        adapter.NotifyDataSetChanged();
        pb.Visibility = ViewStates.Gone;
    }
