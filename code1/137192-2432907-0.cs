        protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (Deployment.Current.Dispatcher == null || Deployment.Current.Dispatcher.CheckAccess())
            {
                base.OnPropertyChanged(sender, e);
            }
            else
            {
                Deployment.Current.Dispatcher.BeginInvoke(() => base.OnPropertyChanged(sender, e));
            }
        }
