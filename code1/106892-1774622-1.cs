    //A draw on drag method to perform the draw
    void DrawOnDrag(Canvas e)
            {
    
                //Get the initial position and dragged points using LINQ to Events
                var mouseDragPoints = from md in e.GetMouseDown()
                                      let startpos=md.EventArgs.GetPosition(e)
                                      from mm in e.GetMouseMove().Until(e.GetMouseUp())
                                      select new
                                      {
                                          StartPos = startpos,
                                          CurrentPos = mm.EventArgs.GetPosition(e),
                                      };
    
    
                //Subscribe and draw a line from start position to current position
                mouseDragPoints.Subscribe
                    (item =>
                    {
                        e.Children.Add(new Line()
                        {
                            Stroke = Brushes.Red,
                            X1 = item.StartPos.X,
                            X2 = item.CurrentPos.X,
                            Y1 = item.StartPos.Y,
                            Y2 = item.CurrentPos.Y
                        });
    
                        var ellipse = new Ellipse()
                        {
                            Stroke = Brushes.Blue,
                            StrokeThickness = 10,
                            Fill = Brushes.Blue
                        };
                        Canvas.SetLeft(ellipse, item.CurrentPos.X);
                        Canvas.SetTop(ellipse, item.CurrentPos.Y);
                        e.Children.Add(ellipse);
                    }
                    );
            }
