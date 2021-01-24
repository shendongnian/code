    private async void ProcessFrameAsync(object sender, EventArgs e)
    {   // async event handlers return void instead of Task
        var grabbedImage = await camera.FetchImageAsync();
        // or if your camera has no async function:
        await Task.Run( () => camera.FetchImage());
        // this might be a length process:
        ProcessImaged(grabbedImage); 
        ShowImage(grabbedImage);
    }
