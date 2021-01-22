    class ByRefTests {
        public static int One(out int i) {
            try {
                i = 1;
                return i;
            } finally {
                // Return value unchanged, Store new value referenced variable
                i = 1000;
            }
        }
        public static int Two(ref int i) {
            try {
                i = 2;
                return i;
            } finally {
                // Return value unchanged, Store new value referenced variable
                i = 2000;
            }
        }
        public static int Three(out int i) {
            try {
                return 3;
            } finally {
                // This is not a compile error!
                // Return value unchanged, Store new value referenced variable
                i = 3000;
            }
        }
    }
