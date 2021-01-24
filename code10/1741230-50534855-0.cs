    UISlider slider = null;
    var volumeView = new MPVolumeView();
    foreach (var view in volumeView.Subviews)
    {
        if (view is UISlider)
        {
            slider = (UISlider)view;
            break;
        }
    }
    slider.Value = 0;
