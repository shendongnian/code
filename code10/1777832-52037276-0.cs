     using (Image<Bgr, byte> imgSrc = BaseImage.Copy())
        {
            while (true)
            {
               //updated and changed TemplateMatchingType- CcoeffNormed.
                using (Image<Gray, float> result = imgSrc.MatchTemplate(SubImage, TemplateMatchingType.CcoeffNormed)) 
                {
                    CvInvoke.Threshold(result, result, 0.7, 1, ThresholdType.ToZero);
                    double[] minValues, maxValues;
                    Point[] minLocations, maxLocations;
                    result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                    if (maxValues[0] > Threashold)
                    {
                        Rectangle match = new Rectangle(maxLocations[0], SubImage.Size);
                        imgSrc.Draw(match, new Bgr(Color.Blue), -1);
                        rectangles.Add(match);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
