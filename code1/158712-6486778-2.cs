        public static int GetHashCode<T>(params T[] args)
        {
            return args.GetArrayHashCode();
        }
        public static int GetArrayHashCode<T>(this T[] objects)
        {
            int[] data = new int[objects.Length];
            for (int i = 0; i < objects.Length; i++)
            {
                T obj = objects[i];
                data[i] = obj == null ? 1 : obj.GetHashCode();
            }
            return GetFnvHash(data);
        }
        private static int GetFnvHash(int[] data)
        {
            unchecked
            {
                const int p = 16777619;
                long hash = 2166136261;
                for (int i = 0; i < data.Length; i++)
                {
                    hash = (hash ^ data[i]) * p;
                }
                hash += hash << 13;
                hash ^= hash >> 7;
                hash += hash << 3;
                hash ^= hash >> 17;
                hash += hash << 5;
                return (int)hash;
            }
        }
