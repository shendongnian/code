    // this task will process grabbed images that are in the buffer
    // until there are no more images to process
    public async Task ProcessGrabbedImagesAsync()
    {
        // wait for data in the buffer
        // stop waiting if no data is expected anymore
        while (await buffer.OutpubAvailableAsync())
        {
            // The producer put some data in the buffer.
            // Fetch it and process it.
            // This may take some time, which is no problem. If the producer has new frames
            // they will be saved in the buffer
            FaceDetection.FaceDetectionFromFrame(imageFrame); // Face detection
            var form = FormFaceDetection.Current;
            form.scanPictureBox.Image = imageFrame.Bitmap;
            faceList.Add(FaceRecognition.AnalyzeFace(imageFrame.Bitmap));
        }
    }
