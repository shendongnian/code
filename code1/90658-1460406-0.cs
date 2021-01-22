    Dictionary<string, decimal> sum = new Dictionary<string, decimal>();
    foreach (IObject obj in objects) {
       if (sum.ContainsKey(obj.Account)) {
          sum[obj.Account].Amount += obj.Amount;
       } else {
          sum.Add(obj.Account, obj.Amount);
       }
    }
