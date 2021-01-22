    public void new Add(MudObject obj)
    {
        obj.ContainedBy = this;
        base.Add(obj);
    }
