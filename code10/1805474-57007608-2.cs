    public static Mat Draw(Mat modelImage, Mat observedImage)
    {
    	Mat homography;
    	VectorOfKeyPoint modelKeyPoints;
    	VectorOfKeyPoint observedKeyPoints;
    	using (VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch())
    	{
    		Mat mask;
    		FindMatch(modelImage, observedImage, out modelKeyPoints, out observedKeyPoints, matches, out mask, out homography);
    		Mat result = new Mat();
    		Features2DToolbox.DrawMatches(modelImage, modelKeyPoints, observedImage, observedKeyPoints,
    			matches, result, new MCvScalar(255, 0, 0), new MCvScalar(0, 0, 255), mask);
    
    		if (homography != null)
    		{
    			var imgWarped = new Mat();
    			CvInvoke.WarpPerspective(observedImage, imgWarped, homography, modelImage.Size, Inter.Linear, Warp.InverseMap);
    			Rectangle rect = new Rectangle(Point.Empty, modelImage.Size);
    			var pts = new PointF[]
    			{
    				  new PointF(rect.Left, rect.Bottom),
    				  new PointF(rect.Right, rect.Bottom),
    				  new PointF(rect.Right, rect.Top),
    				  new PointF(rect.Left, rect.Top)
    			};
    
    			pts = CvInvoke.PerspectiveTransform(pts, homography);
    			var points = new Point[pts.Length];
    			for (int i = 0; i < points.Length; i++)
    				points[i] = Point.Round(pts[i]);
    	
    			using (var vp = new VectorOfPoint(points))
    			{
    				CvInvoke.Polylines(result, vp, true, new MCvScalar(255, 0, 0, 255), 5);
    			}
    		}
    		return result;
    	}
    }
