    public async Task LaunchSafariWebViewAsync(string url, Action action)
    {
        var destination = new NSUrl(url);
        var sfViewController = new SFSafariViewController(destination);
        sfViewController.weakDelegate=this;
        var window = UIApplication.SharedApplication.KeyWindow;
        var controller = window.RootViewController;
        await controller.PresentViewControllerAsync(sfViewController, true);
    }
