    const int blobSizeMin = 1;
    const int blobSizeMax = 5;
    var white = new Bgr(255, 255, 255).MCvScalar;
    Mat frame = CvInvoke.Imread(@"e:\temp\Frame.jpg", ImreadModes.Grayscale);
    Mat mask = CvInvoke.Imread(@"e:\temp\Mask.jpg", ImreadModes.Grayscale);
    frame.CopyTo(frame = new Mat(), mask);
    CvInvoke.BitwiseNot(frame, frame);
    CvInvoke.Threshold(frame, frame, 128, 255, ThresholdType.ToZero);
    Emgu.CV.Cvb.CvBlobs blobs = new Emgu.CV.Cvb.CvBlobs();
    Emgu.CV.Cvb.CvBlobDetector blobDetector = new Emgu.CV.Cvb.CvBlobDetector();
    Image<Gray, Byte> img = frame.ToImage<Gray, Byte>();
    blobDetector.Detect(img, blobs);
    int bulletNumber = 0;
    foreach (var blob in blobs.Values)
    {
        if (blob.BoundingBox.Width >= blobSizeMin && blob.BoundingBox.Width <= blobSizeMax
            && blob.BoundingBox.Height >= blobSizeMin && blob.BoundingBox.Height <= blobSizeMax)
        {
            bulletNumber++;
            Point textPos = new Point((int) blob.Centroid.X - 1, (int) blob.Centroid.Y - 1);
            CvInvoke.PutText(frame, bulletNumber.ToString(), textPos, FontFace.HersheyPlain, 
            fontScale: 1, color: white);
        }
    }
    CvInvoke.Imwrite(@"e:\temp\Out.png", frame);
