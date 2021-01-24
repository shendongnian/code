    Image swatcher = new Image();
            swatcher.Source = new BitmapImage(new Uri("/Icons/physicswheel.png", UriKind.Relative));
            swatcher.Stretch = Stretch.Uniform;
            swatcher.Height = 100;
            swatcher.Width = 100;
            swatcher.Margin = new Thickness(5, 5, 5, 5);
            swatcher.SetValue(Grid.RowProperty, 0);
            swatcher.SetValue(Grid.ColumnProperty, 0);
            swatcher.HorizontalAlignment = HorizontalAlignment.Center;
            columns.Children.Add(swatcher);
            Ellipse bumper = new Ellipse();
            bumper.Height = 95;
            bumper.Width = 95;
            bumper.SetValue(Grid.RowProperty, 0);
            bumper.SetValue(Grid.ColumnProperty, 0);
            bumper.Stroke = new SolidColorBrush(Color.FromArgb(0, 12, 12, 255));
            bumper.StrokeThickness = 17;
            bumper.MouseEnter += delegate (object source, MouseEventArgs e)
            {
                    //Change Mouse Cursor to custom dropper.
                    Uri curDropper = new Uri("/Cursors/eyedropper.cur", UriKind.Relative);
                bumper.Cursor = new Cursor(App.GetResourceStream(curDropper).Stream);
            };
            bumper.MouseDown += delegate (object source, MouseButtonEventArgs e)
            {
                    //Get Mouse position and then grab pixel data.
                    int xPos = Convert.ToInt32(e.GetPosition(swatcher).X);
                int yPos = Convert.ToInt32(e.GetPosition(swatcher).Y);
                CroppedBitmap dropper = new CroppedBitmap(swatcher.Source as BitmapSource, new Int32Rect(xPos, yPos, 1, 1));
                byte[] pixel = new byte[4];
                dropper.CopyPixels(pixel, 4, 0);
                    //Change Swatch Preview and RGB fields.
                    redUpDown.Text = pixel[2].ToString();
                greenUpDown.Text = pixel[1].ToString();
                blueUpDown.Text = pixel[0].ToString();
            };
            columns.Children.Add(bumper);
