    public static class Exts
    {
        public static int Weight(this points ps, int x, int y, int width, int height)
        {
    	     int weight = 0;
            for(int i=Math.Max(x - 1, 0); i<Math.Min(width, x+1))
                for(int j= Math.Max(y-1, 0), j<Math.Min(height, y+1))
       			     if(ps.Any(a => a.X == i && a.Y == j)) weight++;
            return weight;
        }
    
        public static int BlockWeight(this Point[] ps, int x, int y)
        {
            return ps.Count(a => a.X <= x+2 && a.Y<= y+2);
        }	
    }
