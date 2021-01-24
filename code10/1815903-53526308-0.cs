    private static List<Point> GetLocalMaxs(Image<Bgr, byte> image, Image<Bgr, byte> template)
            {
                Image<Gray, float> result = image.MatchTemplate(template, TemplateMatchingType.CcoeffNormed);
                var listOfMaxs = new List<Point>();
                var resultWithPadding = new Image<Gray, float>(image.Size);
                var heightOfPadding = (image.Height - result.Height) / 2;
                var widthOfPadding = (image.Width - result.Width) / 2;
                resultWithPadding.ROI = new Rectangle() { X = heightOfPadding, Y = widthOfPadding, Width = result.Width, Height = result.Height };
                result.CopyTo(resultWithPadding);
                resultWithPadding.ROI = Rectangle.Empty;
    
                for (int i = 0; i < resultWithPadding.Width; i++)
                {
                    for (int j = 0; j < resultWithPadding.Height; j++)
                    {
                        var centerOfRoi = new Point() { X = i + template.Width / 2, Y = j + template.Height / 2 };
                        var roi = new Rectangle() { X = i, Y = j, Width = template.Width, Height = template.Height };
                        resultWithPadding.ROI = roi;
                        double[] minValues, maxValues;
                        Point[] minLocations, maxLocations;
                        resultWithPadding.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                        resultWithPadding.ROI = Rectangle.Empty;
                        var maxLocation = maxLocations.First();
                        if (maxLocation.X == roi.Width / 2 && maxLocation.Y == roi.Height / 2)
                        {
                            var point = new Point() { X = centerOfRoi.X, Y = centerOfRoi.Y };
                            listOfMaxs.Add(point);
                        }
    
                    }
                }
    
                return listOfMaxs;
            }
