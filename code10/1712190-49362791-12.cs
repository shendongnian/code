    private static void DoWorkload(Rectangle bounds, ParallelOptions options, Action<Rectangle?> workload)
    {
       if (options == null)
       {
          workload(null);
       }
       else
       {
          var size = 5 // how many rects to work on, ie 5 x 5
          Parallel.ForEach(bounds.GetSubRects(size), options, rect => workload(rect));
       }
    }
