    public override void Initialize(IComponent component)  
    {
      ...
      view.AutoGenerateColumns = view.DataSource == null;
      ...
    }
