    async void OpenCameraAsync()
    {         
      Func<object> func = () =>
      {
        var obj = DependencyService.Get<IPhotoOverlay>().GetImageOverlay();       
        return obj;
      };
      var photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
      {
         OverlayViewProvider =func,
         DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
      });
    }
