                List<double[]> coordinates = new List<double[]>();
                #region create Polygon Coordinates
                if (!string.IsNullOrWhiteSpace(bus.Latitude) && !string.IsNullOrWhiteSpace(bus.Longitude) && !string.IsNullOrWhiteSpace(bus.ListingRadius))
                {
                    double lat = DegreeToRadian(Double.Parse(bus.Latitude));
                    double lon = DegreeToRadian(Double.Parse(bus.Longitude));
                    double dist = Double.Parse(bus.ListingRadius);
                    double angle = 36;
                    for (double i = 0; i <= 360; i += angle)
                    {
                        var bearing = DegreeToRadian(i);
                        var lat2 = Math.Asin(Math.Sin(lat) * Math.Cos(dist / earthRadius) + Math.Cos(lat) * Math.Sin(dist / earthRadius) * Math.Cos(bearing));
                        var lon2 = lon + Math.Atan2(Math.Sin(bearing) * Math.Sin(dist / earthRadius) * Math.Cos(lat),Math.Cos(dist / earthRadius) - Math.Sin(lat) * Math.Sin(lat2));
                        coordinates.Add(new double[] { RadianToDegree(lat2), RadianToDegree(lon2) });
                    }
                    poly.Coordinates = new[] { coordinates.ToArray() };
                }
                #endregion
