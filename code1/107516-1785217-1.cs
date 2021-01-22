    public static class ComHelper {
        // Release normal RCW objects.
        public static void Release(ref object obj) {
            if (obj == null) {
                return;
            }
            try {
                Marshal.FinalReleaseComObject(obj);
                obj = null;
            } catch (Exception) {
                obj = null;
            } finally {
                GC.Collect();
            }
        }
        // Release "foreach" iterator RCW objects (which are immutable).
        public static void ReleaseIterator(object obj) {
            if (obj == null) {
                return;
            }
            try {
                Marshal.FinalReleaseComObject(obj);
            } finally {
                GC.Collect();
            }
        }
    }
