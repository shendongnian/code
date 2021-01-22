    foreach (var control in controls) {
      var ic = control as IInlineContainer;
      if (ic != null) {
        DoSomething(ic.Inlines);
      }
    }
