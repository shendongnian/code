    public static Mat crop_roi(Mat input_img)
    {
        Image<Gray, byte> img = input_img.ToImage<Gray, byte>();
        double w = input_img.Width;
        double h = input_img.Height;
        Rectangle r = new Rectangle((int)(w * 0.2), (int)(h * 0.4), (int)(w * 0.6), (int)(h * 0.6));
        Image<Gray, byte> output = img.Copy(r);
            
        return output.Mat;
    }
    //USE
    private static void DetectObject(Mat detectionFrame, Mat displayFrame)
    {
        using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
        { 
            //set roi to the frame
            Mat roi = new Mat()
            roi = set_roi(detectionFrame);
            // Build list of contours
            CvInvoke.FindContours(roi , contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
            // Selecting largest contour
            ...
            
            MarkDetectedObject(roi , contours[chosen], maxArea, contours.Size, maxArea);
            
     }
    
