    using System.IO;
    ...
    var streamRef = appListEntry.DisplayInfo.GetLogo(new Windows.Foundation.Size(256, 256));
    var bitmap = new BitmapImage();
    using (var randomAccessStream = await streamRef.OpenReadAsync())
    using (var stream = randomAccessStream.AsStream())
    {
        bitmap.BeginInit();
        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        bitmap.StreamSource = stream;
        bitmap.EndInit();
    }
