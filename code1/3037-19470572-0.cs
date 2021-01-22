     BitmapCacheOption.OnLoad
    var bmp = await System.Threading.Tasks.Task.Run(() => 
    { 
    BitmapImage img = new BitmapImage(); 
    img.BeginInit(); 
    img.CacheOption = BitmapCacheOption.OnLoad; 
    img.UriSource = new Uri(path); 
    img.EndInit(); 
    ImageBrush brush = new ImageBrush(img); 
    
    }
