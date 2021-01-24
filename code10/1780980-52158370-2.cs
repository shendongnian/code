    protected override async void OnActivated(IActivatedEventArgs args)
    {
        await ActivationService.ActivateAsync(args);
    
        if (args.Kind == ActivationKind.Protocol)
        {
            var uriArgs = args as ProtocolActivatedEventArgs;
    
            if (uriArgs != null)
            {
                //DetailPagePage detailpage = new DetailPagePage();
                var stuff = DetailPagePage.pageid;
                MyModel parameter = null;
                if (uriArgs.Uri.Host == stuff.ToLower())
                {
                    switch (stuff)
                    {
                        case "Title1":
                            parameter = new MyModel
                            {
                                Title = "Title1",
                                Subtitle = "My Subtitle 1",
                                Description = "My Description 1 goes here."
                            };
                            break;
                        case "Title2":
                            parameter = new MyModel
                            {
                                Title = "Title2",
                                Subtitle = "My Subtitle 2",
                                Description = "My Description 2 goes here."
                            };
                            break;
                        //Some other case      
                    }
                    NavigationService.Navigate(typeof(DetailPagePage), parameter);
                }
            }
            Window.Current.Activate();
        }
    }
