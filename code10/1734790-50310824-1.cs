    int HEIGHT = 400;
    int WIDTH = 600;
    
    // get the jpg image
    Bitmap bitmap;
    using(Stream bmpStream = System.IO.File.Open(fileName, System.IO.FileMode.Open )){
         Image image = Image.FromStream(bmpStream);
         bitmap = new Bitmap(image);
    }
    for (int x = 0; x < HEIGHT; x++){
      for (int y = 0; y < WIDTH; y++){
        Color pixelColor = bitmap.GetPixel(x, y);
        // check if it's black or a shade of black
        // e.g. if it belongs to an array of colors..etc
        // if so, record the coordinates (x,y)
      }
    } 
