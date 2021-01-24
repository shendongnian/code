    async void OnTapGestureTap(object sender, EventArgs args)
    {
       if(sender is Image image)
       {
          switch (image.Name) // switch on the name
          {
             case "image1":
                await Navigation.PushAsync(new Image1Page());
                break;
             case "image2":
                await Navigation.PushAsync(new Image2Page());
                break;
          }
       }
    }
