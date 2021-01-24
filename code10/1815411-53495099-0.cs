    public void Handle_OnScanResult(Result result)
    {
      Device.BeginInvokeOnMainThread(async () =>
      {
        await DisplayAlert("Scanned result", result.Text, "OK");
      });
    }
