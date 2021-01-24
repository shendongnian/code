    private async Task<Position> GetPositionAsync()
    {
        try
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            return await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
        }
        catch (Exception)
        {
            // handle it properly
            throw;
        }
      }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var position = await GetPositionAsync();
    }
