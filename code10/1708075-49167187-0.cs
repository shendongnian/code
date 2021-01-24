    var result = base.FinishedLaunching(uiApplication, launchOptions);
                try {
                    if (UIApplication.SharedApplication.KeyWindow != null) {
                        double top = 0;
                        double bottom = 0;
                        if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0)) {
                            top = UIApplication.SharedApplication.KeyWindow.SafeAreaInsets.Top;
                            bottom = UIApplication.SharedApplication.KeyWindow.SafeAreaInsets.Bottom;
                        }
    //Store safe area values using NSUserDefaults.StandardUserDefaults 
                        DependencyService.Get<ISettingsService>().AddOrUpdateValue("IPhoneXSafeTop", top);
                        DependencyService.Get<ISettingsService>().AddOrUpdateValue("IPhoneXSafeBottom", bottom);
                        DependencyService.Get<ISettingsService>().Save();
                    }
                } catch (Exception ex) {
                    Console.WriteLine("Ex in FinishedLaunching: " + ex.Message);
                }
                return result;
