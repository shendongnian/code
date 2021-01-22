    public Slot(params Type[] exclusiveLootTypes)
    {
        this.Content = null;
        this.Count = 0;
        this.ExclusiveLootTypes = exclusiveLootTypes.ToList();
    }
