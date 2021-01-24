    private void DrawClientStateIcon(bool isSignedIn)
    {
        Point rectangleLocation = picBoxClientState.Location;
        Size rectangleSize = picBoxClientState.Size;
        Rectangle rectangle = new Rectangle(rectangleLocation, new Size(rectangleSize.Width / 2, rectangleSize.Height / 2));
    
        Color iconColor = isSignedIn ? Color.Green : Color.Red;
    
        using (SolidBrush iconBrush = new SolidBrush(iconColor))
        {
            using (Graphics graphics = picBoxClientState.CreateGraphics())
            {
                graphics.FillEllipse(iconBrush, rectangle);
            }
        }
    }
