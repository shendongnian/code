    var labelsAndAmounts = input
      .GroupJoin
      (
        output,
        i => i.InputId,
        o => o.OutputId,
        (i, os) => new
        {
          i,
          oAmount = os.Any() ? os.Sum() : 0
        }
      )
      .GroupBy(x => x.i.Label)
      .Select(g => new
        {
          Label = g.Key,
          Amount = g.Select(x => x.i.InputAmt + x.oAmount).Sum()
        }
      );
