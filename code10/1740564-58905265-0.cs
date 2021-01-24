public static BitmapDrawable GetDrawable(int resID)
     {
            var context = global::Android.App.Application.Context;
            var drawable = ContextCompat.GetDrawable(context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;
            return new BitmapDrawable(Resources.System, Bitmap.CreateScaledBitmap(bitmap, 60, 60, true));
     }```
//And call like this:
textCtrl.SetCompoundDrawablesRelativeWithIntrinsicBounds(null, null, BitMapHelper.GetDrawable(Resource.Mipmap.eye), null);
You can tweak the scale value to your taste.
Thanks to Billy Liu for the great answer.
