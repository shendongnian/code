    private async void GetCanvasBitmapRegion(Rect RegionToCopy)
            {
                try
                {
                    CanvasDevice Cdevice = CanvasDevice.GetSharedDevice();
    
    
    
                    var croppedwidth = (int)RegionToCopy.Width;
                    var croppedheight = (int)RegionToCopy.Height;
    
                    //create a new empty image that has the same size as the desired crop region
                    var softwareBitmap = new SoftwareBitmap(BitmapPixelFormat.Bgra8, croppedwidth, croppedheight,
                        BitmapAlphaMode.Premultiplied);
    
                    //based on this empty software bitmap we create a new CanvasBitmap
                    var croppedimage = CanvasBitmap.CreateFromSoftwareBitmap(Cdevice, softwareBitmap);
    
                    // this is the image we want to crop from, CanvasBitmap has lots of static initializers that like CanvasBitmap.LoadAsync 
                    //or CanvasBitmap.CreateFromBytes
                    CanvasBitmap initialimage = _image;
    
                    if (initialimage != null)
                    {
    
                        //this function does the cropped region copy.
                        croppedimage.CopyPixelsFromBitmap(_image, 0, 0, (int)RegionToCopy.Left, (int)RegionToCopy.Top, (int)RegionToCopy.Width, (int)RegionToCopy.Height);
    
                     
                       //you can now do whatever you like with croppedimage, including using its .SaveAsync or replace the old one with it.
                    }
    
                }
                catch (Exception Ex)
                {
    
                }
            }
