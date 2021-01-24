    System.Windows.Application.Current.Dispatcher.RunAsync(
            CoreDispatcherPriority.High,
            () =>
            {
                // UI components can be accessed within this scope.
                Click();
            });
