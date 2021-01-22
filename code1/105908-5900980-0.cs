    private bool isSizeChangeDefered;
     private void uiElement_SizeChanged(object sender, SizeChangedEventArgs e)
        {
             //Keep Acpect Ratio
            const double factor = 1.8;
            if(isSizeChangeDefered)
                return;
            isSizeChangeDefered = true;
            try
            {
                if (e.WidthChanged)
                {
                    driverPan.Height = e.NewSize.Width * factor; 
                }
                if (e.HeightChanged)
                {
                    driverPan.Height = e.NewSize.Width / factor; 
                }
            }
            finally
            {
            //    e.Handled = true;
                isSizeChangeDefered = false;
            }
        }
