            private void FrmGraphics_Shown(object sender, EventArgs e)
            {
                DrawClientStateIcon(true);
            }
            private void DrawClientStateIcon(bool isSignedIn)
            {
                Point rectangleLocation = picBoxClientState.Location;
                Size rectangleSize = picBoxClientState.Size;
                Rectangle rectangle = new Rectangle(rectangleLocation, rectangleSize);
    
                Color iconColor = isSignedIn ? Color.Green : Color.Red;
                SolidBrush iconBrush = new SolidBrush(iconColor);
    
                Graphics graphics = base.CreateGraphics();
                graphics.FillEllipse(iconBrush, rectangle);
            }
