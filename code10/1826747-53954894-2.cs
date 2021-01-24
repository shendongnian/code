    internal class shape
    {
        private Bitmap bmp;
        private ImageView img;
        public shape(Bitmap bmp, ImageView img)
        {
            this.bmp = bmp;
            this.img = img;
            onDraw();
        }
        private void onDraw()
        {
            if(bmp.Width == 0 || bmp.Height == 0)
            {
                return;
            }
            
            int w = bmp.Width, h = bmp.Height;
            Bitmap roundBitmap = getHexagonalCroppedBitmap(bmp, h);
            img.SetImageBitmap(roundBitmap);
        }
        private Bitmap getHexagonalCroppedBitmap(Bitmap bitmap, int radius)
        {
            Bitmap finalBitmap;
            if (bitmap.Width != radius || bitmap.Height!= radius)
                finalBitmap = Bitmap.CreateScaledBitmap(bitmap, radius, radius,
                        false);
            else
                finalBitmap = bitmap;
            Bitmap output = Bitmap.CreateBitmap(finalBitmap.Width,
                    finalBitmap.Height, Bitmap.Config.Argb8888);
            Canvas canvas = new Canvas(output);
            Paint paint = new Paint();
            Rect rect = new Rect(0, 0, finalBitmap.Width,
                    finalBitmap.Height);
           
            //note：you could set width and height in here
            int width = 150;
            int height = 150;
            //note: you could set x and y in here, i set the  centerX = width / 2;centerY = height / 2; by default.
            float centerX = width / 2;
            float centerY = height / 2;
            float radiusValue = width / 2;
            double radian30 = 30 * Math.PI / 180;
            float a = (float)(radiusValue * Math.Sin(radian30));
            float b = (float)(radiusValue * Math.Cos(radian30));
            Path path = new Path();
            path.MoveTo(centerX, 0);
         
            path.LineTo(centerX + b, centerY - a);
            path.LineTo(centerX + b, centerY + a);
            path.LineTo(centerX, height);
            path.LineTo(centerX - b, centerY + a);
            path.LineTo(centerX - b, centerY - a);
            path.Close();
            canvas.DrawARGB(0, 0, 0, 0);
            paint.Color=(Color.ParseColor("#BAB399"));
            canvas.DrawPath(path, paint);
            paint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.SrcIn));
            canvas.DrawBitmap(finalBitmap, rect, rect, paint);
            return output;
        }
    }
