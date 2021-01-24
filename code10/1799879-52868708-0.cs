    public class MyRequestListener :Java.Lang.Object, IRequestListener
    {
        public bool OnLoadFailed(GlideException p0, Java.Lang.Object p1, ITarget p2, bool p3)
        {
            return true;
        }
        public bool OnResourceReady(Java.Lang.Object p0, Java.Lang.Object p1, ITarget p2, DataSource p3, bool p4)
        {
            if (p0 is GifDrawable)
            {
                ((GifDrawable)p0).SetLoopCount(1);
            }
            return false;
        }
    }
