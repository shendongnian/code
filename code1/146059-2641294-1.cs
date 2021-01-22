    public EnumExpansion SelectedOptionsExpansion { get; set; }
    public MyControl()
    {
      ...
      SelectedOptionsExpansion = new EnumExpansion();
      BindingOperations.SetBinding(SelectedOptionsExpansion, EnumExpansion.EnumValueProperty,
        new Binding { Path = "SelectedOptions", Source = this });
      ...
    }
    
