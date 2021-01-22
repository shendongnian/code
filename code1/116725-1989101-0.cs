        private void ImageAdded_EventHandler(object sender, ImageAddedEventArgs e)
        {
            Action action = () => ImageAdded(e.Image);
            if (Dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, action);
            }
        }
