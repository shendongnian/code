    if (changedOrNew(myBindingSource)){
        // Do something!
    }
    public bool changedOrNew(BindingSource bs){
        EntityObject obj = (EntityObject)bs.Current;
        if (obj==null)
            return false;
        return (obj.EntityState == EntityState.Detached ||
                obj.EntityState == EntityState.Added ||
                obj.EntityState == EntityState.Modified);
    }
