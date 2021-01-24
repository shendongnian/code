        internal void ReadInCSVPoint3DNew(string absolutePath)
        {
            CultureInfo Culture = new CultureInfo("en-US");
            List<Point3D> result = new List<Point3D>();
            using (TextReader fileReader = File.OpenText(absolutePath))
            {
                var csv = new CsvReader(fileReader);
                csv.Configuration.HasHeaderRecord = false; // The head is not in good format, so, setting it true doesn't work.
                csv.Read(); // Skip Head
                while (csv.Read())
                {
                    Point3D point = new Point3D()
                    {
                        PointX = decimal.Parse(csv.GetField(0), System.Globalization.NumberStyles.Float, Culture),
                        PointY = decimal.Parse(csv.GetField(1), System.Globalization.NumberStyles.Float, Culture),
                        PointZ = decimal.Parse(csv.GetField(2), System.Globalization.NumberStyles.Float, Culture),
                        X = decimal.Parse(csv.GetField(3), System.Globalization.NumberStyles.Float, Culture),
                        Y = decimal.Parse(csv.GetField(4), System.Globalization.NumberStyles.Float, Culture),
                        Z = decimal.Parse(csv.GetField(5), System.Globalization.NumberStyles.Float, Culture),
                        Intensity = int.Parse(csv.GetField(6), System.Globalization.NumberStyles.Float, Culture),
                        LaserIndex = int.Parse(csv.GetField(7), System.Globalization.NumberStyles.Float, Culture),
                        Azimuth = int.Parse(csv.GetField(8), System.Globalization.NumberStyles.Float, Culture),
                        Distance = decimal.Parse(csv.GetField(9), System.Globalization.NumberStyles.Float, Culture),
                        AdjustTime = long.Parse(csv.GetField(10), System.Globalization.NumberStyles.Float, Culture),
                        TimeStamp = long.Parse(csv.GetField(11), System.Globalization.NumberStyles.Float, Culture),
                        VerticalAngle = int.Parse(csv.GetField(12), System.Globalization.NumberStyles.Float, Culture)
                    };
                    result.Add(point);
                }
            }
            this.Data = result;
        }
