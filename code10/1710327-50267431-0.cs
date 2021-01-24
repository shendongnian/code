    protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
                {
                    base.OnElementChanged(e);
    
                    if (e.OldElement != null || Element == null)
                        return;
    
                    if(Build.VERSION.SdkInt >= BuildVersionCodes.N)
                         Element.HeightRequest = 40;
                }
