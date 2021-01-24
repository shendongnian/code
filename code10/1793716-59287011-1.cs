    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
         global::Xamarin.Forms.Forms.Init();
         App.timeZoneName = NSTimeZone.LocalTimeZone.Name;
         LoadApplication(new App());
         return base.FinishedLaunching(app, options);
    }
