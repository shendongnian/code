    private readonly object _entity;
    internal ObjectMaterializedEventArgs(object entity)
    {
      this._entity = entity;
    }
    /// <summary>Gets the entity object that was created.</summary>
    /// <returns>The entity object that was created.</returns>
    public object Entity
    {
      get
      {
        return this._entity;
      }
    }
