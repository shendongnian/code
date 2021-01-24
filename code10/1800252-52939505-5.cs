            TabHost tabHost = FindViewById<TabHost>(Android.Resource.Id.TabHost);
            tabHost.Setup();
            tabHost.TabWidget.GetChildAt(0).SetOnClickListener(new WhatsOnClickListener(tabHost));
            tabHost.TabWidget.GetChildAt(1).SetOnClickListener(new SubsClickListener(tabHost));
            tabHost.TabWidget.GetChildAt(2).SetOnClickListener(new DiscoverClickListener(tabHost));
            tabHost.TabWidget.GetChildAt(3).SetOnClickListener(new MyChannelClickListener(tabHost));
            tabHost.TabWidget.GetChildAt(4).SetOnClickListener(new SettingsClickListener(tabHost));
