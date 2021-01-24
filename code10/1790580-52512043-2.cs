    // Start a consumer task:
    Task taskConsumer = task.Run( () => ProcessGrabbedImagesAsync());
    // subscribe to the camera's event:
    camera.EventImageAvailable += OnImageAvailableAsync;
    camera.StartImageGrabbing();
    // free to do other things
