    async Task GrabAndProcessImages(CancellationToken token)
    {
         // grab the first image:
         var grabbedImage = await camera.GrabImageAsync(token);
         while (!token.CancellationRequested)
         {
              // start grabbing the next image, do not wait for it yet
              var taskGrabImage = camera.GrabImageAsync(token);
              // because I'm not awaiting, I'm free to do other things
              // like processing the last grabbed image:
              ProcessImage(grabbedImage);
              // await for the next image:
              grabbedImage = await taskGrabImage;
         }
    }
