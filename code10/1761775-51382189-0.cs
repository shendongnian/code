    public struct color_map
    {
        private color_map(int r1, int g1, int b1, int r2, int g2, int b2)
        {
            r_start = r1;
            g_start = g1;
            b_start = b1;
            r_end = r2;
            g_end = g2;
            b_end = b2;
        }
        
        public int r_start { get; }
        public int g_start { get; }
        public int b_start { get; }
        public int r_end { get; }
        public int g_end { get; }
        public int b_end { get; }
        
        public static readonly color_map x = new color_map(255, 255, 255, 0, 0, 255);
        public static readonly color_map y = new color_map(255, 255, 255, 255, 0, 0);
        public static readonly color_map z = new color_map(103, 190, 155, 0, 150, 0);
    }
