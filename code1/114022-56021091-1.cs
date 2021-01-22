    private void StartUpScreenLoaded(object sender, RoutedEventArgs e)
        {
            Window StartUpScreen = sender as Window;
            // Dispatcher Format B:
            Dispatcher.Invoke(new Action(() =>
            {
                // Get Actual Window on Loaded
                StartUpScreen.InvalidateVisual();
                System.Windows.Point CoordinatesTopRight = StartUpScreen.TranslatePoint(new System.Windows.Point((StartUpScreen.ActualWidth), (0d)), ActualWindow);
                System.Windows.Point CoordinatesBottomRight = StartUpScreen.TranslatePoint(new System.Windows.Point((StartUpScreen.ActualWidth), (StartUpScreen.ActualHeight)), ActualWindow);
                System.Windows.Point CoordinatesBottomLeft = StartUpScreen.TranslatePoint(new System.Windows.Point((0d), (StartUpScreen.ActualHeight)), ActualWindow);
                // Set the Canvas Top Right, Bottom Right, Bottom Left Coordinates
                System.Windows.Application.Current.Resources["StartUpScreenPointTopRight"] = CoordinatesTopRight;
                System.Windows.Application.Current.Resources["StartUpScreenPointBottomRight"] = CoordinatesBottomRight;
                System.Windows.Application.Current.Resources["StartUpScreenPointBottomLeft"] = CoordinatesBottomLeft;
            }), DispatcherPriority.Loaded);
        }
