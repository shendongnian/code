        private void cvsTest_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point ptClicked = e.GetPosition(cvsTest);
            if (e.LeftButton.Equals(MouseButtonState.Pressed))
            {
                Color pxlColor = ImagingTools.GetPixelColor(cvsTest, ptClicked);
                MessageBox.Show("Color String = " + pxlColor.ToString());
            }
        }
