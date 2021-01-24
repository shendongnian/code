            try
            {
                var scanPage = new ZXingScannerPage();
                scanPage.IsScanning = true;
                scanPage.OnScanResult += (result) =>
                {
                // Stop scanning
                scanPage.IsScanning = false;
                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Navigation.PopAsync(true);
                        await DisplayAlert("Scanned Code", result.Text, "OK");
                    });
                };
                Navigation.PushAsync(scanPage);
            }
            catch
            {
                // handle exception
            }
