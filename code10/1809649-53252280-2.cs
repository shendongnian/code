    public static class Exts
    {
        public static int Weight(this Point p, int width, int height)
        {
    	     int weight = 0;
            for(int i=Math.Max(p.X-1, 0); i<Math.Min(width, p.X+1))
                for(int j= Math.Max(p.Y-1, 0), j<Math.Min(height, p.Y+1))
       			     weight++;
            return weight;
        }
    
        public static int BlockWeight(this Point[] ps, int x, int y)
        {
            return ps.Count(a => a.X <= x+2 && a.Y<= y+2);
        }	
    }
