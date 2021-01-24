     /// <summary>
            /// Draw an arc with .Net code
            /// </summary>
            /// <param name="a">Start point</param>
            /// <param name="b">Stop oint</param>
            /// <param name="centerPoint">Center point</param>
            /// <param name="nauticalMiles"></param>
            /// <returns></returns>
            public static string ExactArtGpsCoordinate(TfrXY a, TfrXY b, TfrXY centerPoint, decimal nauticalMiles)
            {
                //Notice database store longitude then latitude
                StringBuilder coordinates = new StringBuilder();
                DbGeography point = DbGeography.PointFromText(string.Format("POINT ({0} {1})", centerPoint.LngX, centerPoint.LatY), DbGeography.DefaultCoordinateSystemId);
                // create a circle around a point, convert from Nautical Miles to Kilometers
                var radius = UniversalWeather.Weather.API.Utility.MetricConversions.MetricConversions.NauticalMilesToMeters(nauticalMiles);
                DbGeography orig = point.Buffer(Convert.ToDouble(radius));
                string resultData = orig.AsText();
    
                //Clean data
                resultData = resultData.Replace("POLYGON ((", "");
                resultData = resultData.Replace(", ", ",0\n");
                resultData = resultData.Replace("))", ",0");
                resultData = resultData.Replace(" ", ",");
    
                //Convert the circular coordinate into array
                string[] splitCoordinates = resultData.Split('\n');
                bool IsEastToWest = false;
                #region Determinte direction
                if (a.LngX > b.LngX)
                {
                    IsEastToWest = true;
                }
                #endregion
               
                //Add stop point
                coordinates.Append(b.LngX.ToString() + "," + b.LatY.ToString() + ",0\n");
                
                //Help to split the calculation for the arc
                double middleX = (a.LngX + b.LngX) / 2f;
                double middleY = (a.LatY + b.LatY) / 2f;
    
                for (int i = 0; i < splitCoordinates.Length; i++)
                {
                    //split data to long then lat
                    string[] temp = splitCoordinates[i].Split(',');
                    //Current longitude
                    double cx = Convert.ToDouble(temp[0]);
                    double cy = Convert.ToDouble(temp[1]);
    
                    #region Logic for East to West
                    if (IsEastToWest)
                    {
                        ////Half East
                        if (a.LatY > cy && middleX <= cx)
                        {
                            coordinates.Append(splitCoordinates[i] + "\n");
                        }
                        //Half West
                        else if (middleX >= cx && b.LatY >= cy)
                        {
                            coordinates.Append(splitCoordinates[i] + "\n");
                        }
                    }
                    #endregion
                    #region Logic for West to EAST
                    else
                    {
                        //Half West
                        if (a.LatY < cy && middleX >= cx)
                        {
                            coordinates.Append(splitCoordinates[i] + "\n");
                        }
                        //Half East
                        else if (middleX <= cx && cx < b.LngX && cy > centerPoint.LatY)
                        {
                            coordinates.Append(splitCoordinates[i] + "\n");
                        }
                    } 
                    #endregion
                }
                //Add start point
                 coordinates.Append(a.LngX.ToString() + "," + a.LatY.ToString() + ",0\n");
                return coordinates.ToString();
            }
