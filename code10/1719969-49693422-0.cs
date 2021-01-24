    for (int i = cases.Count - 1; i >= 0; i--)
    {
      var tpCase = cases[i];
      if (tpCase.NextRenewalCycle == null || tpCase.NextRenewalCycle.OrderRows.Any())
      {
        cases.RemoveAt(i);
      }
    }
