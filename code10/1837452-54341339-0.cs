    public CustomLabel()
    {
        this.SizeChanged += CustomLabel_SizeChanged;
        this.LayoutUpdated += CustomLabel_LayoutUpdated;
    }
    private void CustomLabel_LayoutUpdated(object sender, object e)
    {
        CalculateContentPosition();
    }
