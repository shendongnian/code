    private static void OnComponentPreparing(object sender, PreparingEventArgs e)
    {
        e.Parameters = e.Parameters.Union(
          new[]
          {
             new ResolvedParameter(
                (p, i) => p.ParameterType == typeof(ILog),
                (p, i) => LogManager.GetLogger(p.Member.DeclaringType)
             ),
          });
    }
