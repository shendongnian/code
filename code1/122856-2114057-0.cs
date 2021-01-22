    Foo.Render = (a, b) =>
    {
      var stopWatch = System.Diagnostics.Stopwatch.StartNew();
      a.RenderPartial(b);
      System.Diagnostics.Debug.WriteLine("Rendered " + b.ToString() + " in " + stopWatch.ElapsedMilliseconds);
      return "";
    };
