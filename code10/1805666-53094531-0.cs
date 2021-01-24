    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
            {
                global::Xamarin.Forms.Forms.Init();
    
    
                startTimeMillis = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
    
                double delay = 750 - (DateTime.Now.Ticks / TimeSpan.TicksPerSecond - startTimeMillis);
                if (delay > 0)
                {
                    Task.Delay(5000).Wait();
    
                    LoadApplication(new App());
    
                    return base.FinishedLaunching(app, options);
    
                }
                else
                {
                    LoadApplication(new App());
                    return base.FinishedLaunching(app, options);
    
                }
    
            }
