    var stopWatch = new System.Diagnostics.Stopwatch();
    for(int i = 0; i < 100; i++) {
      stopWatch.Restart();
      DeleteEmptySubdirectories(rootPath);
      stopWatch.Stop();
      StatusOutputStream.WriteLine("Parallel: "+stopWatch.ElapsedMilliseconds);
      stopWatch.Restart();
      DeleteEmptySubdirectoriesSingleThread(rootPath);
      stopWatch.Stop();
      StatusOutputStream.WriteLine("Single: "+stopWatch.ElapsedMilliseconds);
    }
