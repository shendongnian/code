        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.Run(async () =>
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(TimeSpan.FromMinutes(3), includeHeading: true);
                Device.BeginInvokeOnMainThread(() =>
                {
                    Entry_Longitude.Text = position.Longitude.ToString();
                    Entry_Latitude.Text = position.Latitude.ToString();
                });
            });
        }
