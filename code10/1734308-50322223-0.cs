    private void initFontScale()
    {
         Configuration configuration = Resources.Configuration;
         configuration.FontScale = (float)1.45;
         //0.85 small, 1 standard, 1.15 big，1.3 more bigger ，1.45 supper big 
         DisplayMetrics metrics = new DisplayMetrics();
         WindowManager.DefaultDisplay.GetMetrics(metrics);
         metrics.ScaledDensity = configuration.FontScale * metrics.Density;
         BaseContext.Resources.UpdateConfiguration(configuration, metrics);
    }
    protected override void OnCreate(Bundle bundle)
    {
        initFontScale();
        ...
    }
