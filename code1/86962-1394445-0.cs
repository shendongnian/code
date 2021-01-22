      Type created = eb.CreateType();
      eb.SetCustomAttribute(new CustomAttributeBuilder(
        typeof(TransitionToAttribute).GetConstructors().First(),
        new object[] { Enum.Parse(created, "A") }));
      fb.SetCustomAttribute(new CustomAttributeBuilder(
        typeof(TransitionToAttribute).GetConstructors().First(),
        new object[] { Enum.Parse(created, "A") }));
