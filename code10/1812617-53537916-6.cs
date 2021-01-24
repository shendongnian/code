        using (Graphics g2 = pictureBox.CreateGraphics())
        {
            float scaleX = g2.DpiX / img.HorizontalResolution / scale;
            float scaleY = g2.DpiY / img.VerticalResolution / scale;
            g2.ScaleTransform(scaleX, scaleY);
            g2.DrawImage(img, 0, 0);    // draw the original emf image.. (*)
            g2.ResetTransform();
            // g2.DrawImage(bmp, 0, 0); // .. it will look the same as (*)
            g2.DrawRectangle(Pens.Black, rScaled);
        }
