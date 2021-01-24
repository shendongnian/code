      using System.Reflection;
      ...
      ErrorProvider provider = GetType()
        .GetField($"errorProvider{count}", BindingFlags.Instance | BindingFlags.NonPublic)
        .GetValue(this) as ErrorProvider;
      provider.SetError(tb, "Please enter a value");
      ... 
