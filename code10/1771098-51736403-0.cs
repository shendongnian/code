    void OnCalloutAccessoryControlTapped(object sender, MKMapViewAccessoryTappedEventArgs e)
            {
                // handle navigation here instead of opening the webpage
                var customView = e.View as CustomMKAnnotationView;
                if (!string.IsNullOrWhiteSpace(customView.Url))
                {
                    UIApplication.SharedApplication.OpenUrl(new Foundation.NSUrl(customView.Url));
                }
            }
