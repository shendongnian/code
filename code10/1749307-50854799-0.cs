    public static bool AddNode<T>(ProjectEntities DBContext, LocalUser User, T ParentEntity) where T:TblBase
    {
        var BaseEntity = (TblBase)ParentEntity;
        var ChildType = ((IHasChildren)ParentEntity).Children.GetType().GetGenericArguments()[0];
        T NewNode = new tblLine
        {
            ParentID = BaseEntity.ID,
            COID = User.ID,
            IsSelected = true,
            IsExpanded = true
        } as T;
         DBContext.Set<T>().Add(NewNode);
    //may want to call DBContext.SaveChanges() here if no further actions to be taken
        return true;
    }
