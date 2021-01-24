    protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        base.OnElementPropertyChanged(sender, e);
        if (e.PropertyName == nameof(FabButton.ButtonColor))
            Control.BackgroundColor = ((FabButton) Element).ButtonColor.ToUIColor();
        else if(e.PropertyName == nameof(FabButton.ButtonHost)){
            var fabButton = (FabButton)Element;
            if (fabButton.ButtonHost != null && fabButton.ButtonHost.ShouldBeHiddenWhenScrolling)
            {
                fabButton.ButtonHost.LinkedScrollViewScrolled += OnLinkedScrollView_Scrolled;
            }
        }
    }
