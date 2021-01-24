    async void OnTapGestureTap(object sender, EventArgs args)
    {
        var image = sender as Image;
        switch (image.ClassId)
        {
            case "image1":
                await Navigation.PushAsync(new Image1Page());
                break;
            case "image2":
                await Navigation.PushAsync(new Image2Page());
                break;
        }
    }
