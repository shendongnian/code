       for (int i = 0; i < nics.Count; i++)
       {
             int j = i;
             rs[i] = new RollingSeries(monitor, new RollingSeries.NextValueDelegate(delegate()
             {
                return GetNetworkUtilization(nics[j]);
              }));
        }
