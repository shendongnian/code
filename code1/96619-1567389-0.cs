    public static class Helper
    {
        public static List<int> To(this int start, int stop)
        {
            List<int> list = new List<int>();
            for (int i = start; i <= stop; i++) {
                list.Add(i);
            }
            return list;
        }
    }
