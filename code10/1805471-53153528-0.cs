    public static Mat GetHomography(VectorOfKeyPoint keypointsModel, VectorOfKeyPoint keypointsTest, List<MDMatch[]> matches)
    {
      MKeyPoint[] kptsModel = keypointsModel.ToArray();
      MKeyPoint[] kptsTest = keypointsTest.ToArray();
    
      PointF[] srcPoints = new PointF[matches.Count];
      PointF[] destPoints = new PointF[matches.Count];
    
      for (int i = 0; i < matches.Count; i++)
      {
        srcPoints[i] = kptsModel[matches[i][0].TrainIdx].Point;
        destPoints[i] = kptsTest[matches[i][0].QueryIdx].Point;
      }
    
      Mat homography = CvInvoke.FindHomography(srcPoints, destPoints, Emgu.CV.CvEnum.HomographyMethod.Ransac);
    
      //PrintMatrix(homography);
    
      return homography;
    }
