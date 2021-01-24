     private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                var point = Mouse.GetPosition(canvas);
                Rect newrect = new Rect(point.X, point.Y, 100, 100);
                Boolean isIntersects = false;
                foreach (Control control in canvas.Children)
                {
                    if (control is Label)
                    {
                        Rect oldrect = new Rect(Canvas.GetLeft(control), Canvas.GetTop(control), control.Width, control.Height);
                        if (newrect.IntersectsWith(oldrect))
                        {
                            MessageBox.Show("Oops. Intersecting...");
                            isIntersects = true;
                            break;
                        }
                    }
                }
                if (isIntersects == false)
                {
                    Label label = new Label() { Width = 100, Height = 100 };
                    label.Content = "This is a label:)";
                    label.Background = new SolidColorBrush(Colors.Yellow);
                    canvas.Children.Add(label);
                    Canvas.SetLeft(label, point.X);
                    Canvas.SetTop(label, point.Y);
                }
            }
