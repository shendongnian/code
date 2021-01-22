    if (changedOrNew(myBindingSource)){
        // Do something!
    }
    public bool changedOrNew(BindingSource bs){
        EntityObject obj = BindingSource.Current;
        if (obj==null) return false;
        return (obj.EntityState == EntityState.Detached || obj.EntityState == EntityState.Added || obj.EntityState == EntityState.Modified);
    }
