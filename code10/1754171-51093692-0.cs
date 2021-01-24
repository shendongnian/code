    private async void CreateVideoFromWritableBitmapAsync(List<WriteableBitmap> WBs)
    {
        var mediaComposition = new MediaComposition();
        foreach (WriteableBitmap WB in WBs)
        {
            var pixels = WB.PixelBuffer.ToArray();
            CanvasBitmap bitmap = CanvasBitmap.CreateFromBytes(CanvasDevice.GetSharedDevice(), pixels,
                    64, 64, DirectXPixelFormat.B8G8R8A8UIntNormalized);
            MediaClip mediaClip = MediaClip.CreateFromSurface(bitmap, TimeSpan.FromSeconds(1));
            mediaComposition.Clips.Add(mediaClip);
        }
        //Save the video
        var file =await ApplicationData.Current.LocalFolder.CreateFileAsync("WBVideo.mp4");
        await mediaComposition.SaveAsync(file);
        mediaComposition=await MediaComposition.LoadAsync(file);
        await mediaComposition.RenderToFileAsync(file);
    }
