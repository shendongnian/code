        public static byte[] Concat(params byte[][] arrays) {
            using (var mem = new MemoryStream(arrays.Sum(a => a.Length))) {
                foreach (var array in arrays) {
                    mem.Write(array, 0, array.Length);
                }
                return mem.ToArray();
            }
        }
