    public double DipsToPixelsX(double input)
    {
        return input * PresentationSource.FromVisual(Application.Current.Windows[0]).CompositionTarget.TransformToDevice.M11;
    }
    public double DipsToPixelsY(double input)
    {
        return input * PresentationSource.FromVisual(Application.Current.Windows[0]).CompositionTarget.TransformToDevice.M22;
    }
    public double PixelsToDipsX(double input)
    {
        return input / PresentationSource.FromVisual(Application.Current.Windows[0]).CompositionTarget.TransformToDevice.M11;
    }
    public double PixelsToDipsY(double input)
    {
        return input / PresentationSource.FromVisual(Application.Current.Windows[0]).CompositionTarget.TransformToDevice.M22;
    }
