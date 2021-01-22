    foreach (var control in controls) {
      var ir = new InlinesResolver(control);
      if (ir.HasInlines) {
        DoSomething(icr.Inlines);
      }
    }
