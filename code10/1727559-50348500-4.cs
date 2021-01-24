            Image<Bgr, byte> source = new Image<Bgr, byte>(ofd.FileName);
            // Preferably use Path.Combine here:
            string dir = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            // Check whether directory exists:
            if (!Directory.Exists(dir))
                throw new ArgumentException($"Directory was not found: '{dir}'");
            // It looks like you just need filenames here...
            // Simple parallel foreach suggested by HouseCat (in 2.):
            Parallel.ForEach(Directory.GetFiles(dir), (fname) =>
            {
                Image<Gray, float> result = source.MatchTemplate(
                    new Image<Bgr, byte>(fname.FullName),
                    Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);
                // By using C# 7.0, we can do inline out declarations here:
                result.MinMax(
                    out double[] minValues,
                    out double[] maxValues,
                    out Point[] minLocations,
                    out Point[] maxLocations);
                if (maxValues[0] > 0.96)
                {
                    // ...
                    var result = ...
                    return result; // <<< As suggested by: denfromufa
                }
                // ...
            });
