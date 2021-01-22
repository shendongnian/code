    for (int i = 0; i < nics.Count; i++)
       {
             int localI = i;
             rs[i] = new RollingSeries(monitor, new RollingSeries.NextValueDelegate(delegate()
             {
                return GetNetworkUtilization(nics[localI]);
              }));
        }
