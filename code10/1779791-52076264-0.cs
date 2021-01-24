     ...
     sp.Children.Add(p);
            foreach (var slot in group)
            {
                var color = colors[(int)slot.State];
                var name = String.Format("W{0}", slot.When.ToString("yyyyMMddHHmm"));
                Rectangle rect = new Rectangle
                {
                    Name = name,
                    Width = rectWidth,
                    Height = rectWidth,
                    Margin = new Thickness(rectMargin),
                    Stroke = new SolidColorBrush(slot.State == Availability.Booked ? Colors.White : Colors.Black),
                    StrokeThickness = 1,
                    Fill = new SolidColorBrush(color),
                    RadiusX = 2,
                    RadiusY = 2,
                    Cursor = (slot.State == Availability.Booked ? Cursors.Arrow : Cursors.Hand)
                };
                if (slot.State != Availability.Booked)
                {
                    rect.Effect = new DropShadowEffect(); //myDropShadowEffect,
                }
                if (slot.State != Availability.Booked)
                {
                    rect.MouseLeftButtonDown += new MouseButtonEventHandler(rect_MouseLeftButtonDown);
                    ToolTipService.SetToolTip(rect, slot.When.ToString("MMM dd,yyyy dddd hh:mm tt"));
                }
                sp.Children.Add(rect);
            }
            b.Child = sp;
            contentStackPanel.Children.Add(b);
        }
