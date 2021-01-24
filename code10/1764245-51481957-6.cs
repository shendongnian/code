    private void MoveCarretToEnd(object sender, RoutedEventArgs e)
    {
        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            //wait until current event queue is handled
        {
            LabelFreeText.CaretIndex = LabelFreeText.Text.Length;
        }));
    }
