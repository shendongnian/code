      using System.Reflection;
      ...
      foreach (TextBox tb in this.Controls.OfType<TextBox>()) {
        ...
        // Obtain errorProviderCount via Reflection
        ErrorProvider provider = GetType()
          .GetField($"errorProvider{count}", BindingFlags.Instance | BindingFlags.NonPublic)
          .GetValue(this) as ErrorProvider;
        provider.SetError(tb, "Please enter a value");
        ... 
      }
