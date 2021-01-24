    NativeGallery.Permission permission = NativeGallery.CheckPermission();
    if (permission == NativeGallery.Permission.ShouldAsk) 
    {
         permission = NativeGallery.RequestPermission();
         Debug.Log("Asking");
    }
    // If we weren't denied but told to ask, this will handle the case if the user denied it.
    // otherwise if it was denied then we return and do not attempt to save the screenshot
    if (permission == NativeGallery.Permission.Denied) 
    {
         Debug.Log("Not allowed");
         return;
    }
    Debug.Log("Path is "+NativeGallery.GetSavePath("GalleryTest","My_img_{0}.png"));
    //Output ==>  /storage/emulated/0/DCIM/GalleryTest/My_img_1.png
    
    Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
    ss.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
    ss.Apply();
    
    Debug.Log("Secondlast");
    permission = NativeGallery.SaveImageToGallery( ss, "GalleryTest", "My_img_{0}.png" ) ;
    
    Debug.Log("Done screenshot");
