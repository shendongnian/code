    public void ConfigureTransform(int viewWidth, int viewHeight)
    {
        int rotation = (int)ThisActivity.WindowManager.DefaultDisplay.Rotation;
        var matrix = new Matrix();
        var viewRect = new RectF(0, 0, viewWidth, viewHeight);
        var bufferRect = new RectF(0, 0, previewSize.Height, previewSize.Width);
        float centerX = viewRect.CenterX();
        float centerY = viewRect.CenterY();
        //Set the scale accordingly, to have the preview texture view fill the whole screen with cutting of the least amount of the preview as possible 
        //(but this way we keep the aspect ratio -> no preview distortion)
        bool isLandscape = ((int)SurfaceOrientation.Rotation90 == rotation || (int)SurfaceOrientation.Rotation270 == rotation);
        float scale;
        if (isLandscape)
        {
            scale = System.Math.Max(
                (float)viewWidth / previewSize.Height,
                (float)viewWidth / previewSize.Width);
        }
        else
        {
             scale = System.Math.Max(
                (float)viewHeight / previewSize.Height,
                (float)viewHeight / previewSize.Width);
        }
        if ((int)SurfaceOrientation.Rotation90 == rotation || (int)SurfaceOrientation.Rotation270 == rotation || (int)SurfaceOrientation.Rotation180 == rotation)
        {
            bufferRect.Offset((centerX - bufferRect.CenterX()), (centerY - bufferRect.CenterY()));
            matrix.SetRectToRect(viewRect, bufferRect, Matrix.ScaleToFit.Fill);
            matrix.PostScale(scale, scale, centerX, centerY);
            //Small check if orientation is Reverse Portrait -> dont substract 2 from rotation, otherwise the preview is flipped by 180°
            if ((int)SurfaceOrientation.Rotation180 == rotation)
                matrix.PostRotate(90 * rotation, centerX, centerY);
            else
                matrix.PostRotate(90 * (rotation - 2), centerX, centerY);
        }
        TextureView.SetTransform(matrix);
    }
