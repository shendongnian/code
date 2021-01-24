    private static UIViewController GetController()
    {
        var vc = UIApplication.SharedApplication.KeyWindow.RootViewController;
        while (vc.PresentedViewController != null  && vc.PresentedViewController.ToString().Contains("Xamarin_Forms_Platform_iOS_ModalWrapper"))
            vc = vc.PresentedViewController;
        return vc;
    }
