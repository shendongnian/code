        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == HybridWebView.UriProperty.PropertyName)
            {
                if (Control.Uri != null)
                    Control.Source = new Uri(Control.Uri);
            }
        }
