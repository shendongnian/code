    NativeGallery.Permission permission = NativeGallery.CheckPermission();
    if (permission == NativeGallery.Permission.Granted) 
    {
         Debug.Log("May proceed");
    }
    else 
    {
         Debug.Log("Not allowed");
         // You do not break out of the function here so it will attempt to save anyways
    }
