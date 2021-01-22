    foreach (PinnacleStock ps in p.StockList.Where(x => x.ColorCode == "10" && 
                                                        x.PackageLength == 30.64))
    {
      for (int i = 1; i <= ps.OnOrder; i++)
      {
        PinnacleStock clone = ps.CopySomehow();  // your problem
        r.TryAddPackage((IPackage)clone);
      }
    }
