    class Test2 {
        public static System.IO.MemoryStream BadStream(byte[] buffer) {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer);
            try {
                return ms;
            } finally {
                // Reference unchanged, Referenced Object changed
                ms.Dispose();
            }
        }
    }
