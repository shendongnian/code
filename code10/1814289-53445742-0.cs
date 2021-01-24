            Bitmap greyBitmap = Bitmap.CreateBitmap(1000, 500, Bitmap.Config.Argb8888);
            Canvas canvas = new Canvas(greyBitmap );
            Paint paint = new Paint();
            paint.Color = new Color(Color.ParseColor("#eeeeee")); // set any color here 
            canvas.DrawRect(0, 0, 1000, 500, paint);
            vh.dr = new BitmapDrawable(greyBitmap );
