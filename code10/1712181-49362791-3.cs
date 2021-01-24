    private static void DoWorkload(Rectangle bounds, BitmapParallelOptions options, Action<Rectangle?> workload)
    {
       if (options == null)
       {
          workload(null);
       }
       else
       {
          Parallel.ForEach(bounds.GetSubRects(options.TableSize), options.ParallelOptions, rect => workload(rect));
       }
    }
