    ...
    geocodeService.ReverseGeocodeCompleted += ReverseGeocodeCompleted(se, ev);
    geocodeService.ReverseGeocodeAsync(reverseGeocodeRequest);
    }
        private void ReverseGeocodeCompleted(object sender, ReverseGeocodeCompletedEventArgs e)
        {
          try
            {
                // something went wrong ...
                var address = e.Result.Results[0].Address;
            }
            catch (Exception)
            { // Catch Exception
                Debug.WriteLine("NO INTERNET CONNECTION");
            }
