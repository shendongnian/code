      Route route = r.ResourceSets[0].Resources[0] as Route;
    
                            double[][] routePath = route.RoutePath.Line.Coordinates;
                            LocationCollection locs = new LocationCollection();
    
                            for (int i = 0; i < routePath.Length; i++)
                            {
                                if (routePath[i].Length >= 2)
                                {
                                    locs.Add(new Microsoft.Maps.MapControl.WPF.Location(routePath[i][0], routePath[i][1]));
                                }
                            }
    
                            MapPolyline routeLine = new MapPolyline()
                            {
                                Locations = locs,
                                Stroke = new SolidColorBrush(Colors.Blue),
                                StrokeThickness = 5
                            };
    
                            MyMap.Children.Add(routeLine);
