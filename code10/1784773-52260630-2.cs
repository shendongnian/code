    private async Task FlipImagesAsync()
    {
        while (true)
        {
            await Task.Delay(5000); // I'm not entirely sure about the amount of seconds you want to wait here
            Device.BeginInvokeOnMainThread(() =>
            {
                ImgCCF.Source = ImageSource.FromResource("Agtmovel.Img.cartFront.png");
                ImgCCF.IsVisible = true;
                ImgCCV.IsVisible = false;
            });
            await Task.Delay(8000); // I'm not entirely sure about the amount of seconds you want to wait here
            Device.BeginInvokeOnMainThread(() =>
            {
                ImgCCV.Source = ImageSource.FromResource("Agtmovel.Img.cartBack.png");
                ImgCCV.IsVisible = true;
                ImgCCF.IsVisible = false;
            });
        }
    }
