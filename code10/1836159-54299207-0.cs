    private void OnNewGPS()
    {
        mainActivity.RunOnUiThread(() =>
        {
            overlay.Visibility = ViewStates.Gone;     });
    }
    
    private void NoGPS()
    {
        mainActivity.RunOnUiThread(() =>
        {
            overlay.Visibility = ViewStates.Visible;
        });
    }
