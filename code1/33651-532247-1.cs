    public static class DataContextExt {
        public static T NoTracking<T>(this T ctx)
            where T : DataContext
        {
            ctx.ObjectTrackingEnabled = false;
            return ctx;
        }   
    
    }
