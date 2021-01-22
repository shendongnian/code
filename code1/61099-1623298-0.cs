    public static class ToolTipServiceHelper
    {
        static ToolTipServiceHelper()
        {
            ToolTipService.InitialShowDelayProperty
                .OverrideMetadata(typeof(FrameworkElement), 
                                  new FrameworkPropertyMetadata(...));
        }
    }
