    public void MakeViewShot(Xamarin.Forms.View view)
    {
        var nativeView = view.GetRenderer().View;
        var wasDrawingCacheEnabled = nativeView.DrawingCacheEnabled;
        nativeView.DrawingCacheEnabled = true;
        nativeView.BuildDrawingCache(false);
        var bitmap = nativeView.GetDrawingCache(false);
        // TODO: Save bitmap and return filepath
        nativeView.DrawingCacheEnabled = wasDrawingCacheEnabled;
    }
