    public static class Extensions
    {
       public static Color NextColor(this Random r) => Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
          
       public static FillObject GetObject(this List<FillObject> objects, int maxSize, Random rand)
       {
          var nextObjs = objects.Where(o => o.Width <= maxSize)
                                  .ToList();
          return nextObjs[rand.Next(nextObjs.Count)];
       }
    }
