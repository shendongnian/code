     When(p => p.LampModel== LampType.NoCover.ID, () =>
     {
         RuleFor(p => p).Must(p => p.LampType== LampType.Open.ID);
     });
     When(p => p.LampModel != LampType.NoCover.ID, () =>
     {
         RuleFor(p => p).Must(p => p.LampType == LampType.Closed.ID);
     });
