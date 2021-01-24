    await CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
         Frame newframe = new Frame();
         newframe.Navigate(typeof(Page2), this);
         Window.Current.Content = newframe;
         Window.Current.Activate();
         NewWindowid = ApplicationView.GetForCurrentView().Id;
    });
    await CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
         Point ptr = args.CurrentPoint.Position;
         double Xpage2 = ptr.X;
         mainpage.copyX(Xpage2);
    });
