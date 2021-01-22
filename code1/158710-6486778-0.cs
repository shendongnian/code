        public static int GetHashCode<T>(params T[] args)
        {
            return args.GetArrayHashCode();
        }
        public static int GetArrayHashCode<T>(this T[] objects)
        {
            byte[] data = new byte[objects.Length * 4];
            for (int i = 0; i < objects.Length; i++)
            {
                T obj = objects[i];
                // I generate the same values for any null array, but that's my choice
                byte[] datum = new byte[] { 0, 0, 0, 0 };
                if (obj != null)
                {
                    datum = BitConverter.GetBytes(obj.GetHashCode());
                }
                datum.CopyTo(data, i * 4);
            }
            return GetFnvHash(data);
        }
        private static int GetFnvHash(byte[] data)
        {
            unchecked
            {
                const int p = 16777619;
                int hash = (int)2166136261;
                for (int i = 0; i < data.Length; i++)
                    hash = (hash ^ data[i]) * p;
                hash += hash << 13;
                hash ^= hash >> 7;
                hash += hash << 3;
                hash ^= hash >> 17;
                hash += hash << 5;
                return hash;
            }
        }
