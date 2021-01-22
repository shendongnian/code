    context.Load(context.GetMyStatusValues1Query()).Completed += (s, e) =>
      {
        this.StatusValues1 = context.StatusValues1;
      }
    
    context.Load(context.GetMyStatusValues2Query()).Completed += (s1, e1) =>
      {
        this.StatusValues1 = context.StatusValues2;
      }
