     //Compare the preview size closest to the aspect ratio by comparison (if the same size, preference)
     //return Get the closest to the original width ratio
       public static Camera.Size getCloselyPreSize(bool isPortrait, int surfaceWidth, int surfaceHeight, List<Camera.Size> preSizeList)
        {
            int reqTmpWidth;
            int reqTmpHeight;
            // When the screen is vertical, you need to change the width and height to ensure that the width is greater than the height.
            if (isPortrait)
            {
                reqTmpWidth = surfaceHeight;
                reqTmpHeight = surfaceWidth;
            }
            else
            {
                reqTmpWidth = surfaceWidth;
                reqTmpHeight = surfaceHeight;
            }
            //First find the size of the same width and height as the surfaceview in the preview.
            foreach (Camera.Size size in preSizeList)
            {
                if ((size.Width == reqTmpWidth) && (size.Height == reqTmpHeight))
                {
                    return size;
                }
            }
            // Get the size closest to the incoming aspect ratio
            float reqRatio = ((float)reqTmpWidth) / reqTmpHeight;
            float curRatio, deltaRatio;
            float deltaRatioMin = Float.MaxExponent;
            Camera.Size retSize = null;
            foreach (Camera.Size size in preSizeList)
            {
                curRatio = ((float)size.Width) / size.Height;
                deltaRatio = System.Math.Abs(reqRatio - curRatio);
                if (deltaRatio < deltaRatioMin)
                {
                    deltaRatioMin = deltaRatio;
                    retSize = size;
                }
            }
            return retSize;
        }
