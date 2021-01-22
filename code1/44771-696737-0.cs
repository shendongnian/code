    public AddMyColumn(DelegateGrid.ValueGetter getter) {
      if (lastGetter != null) {
        DelegateGrid.ValueGetter newLastGetter = lastGetter;
        base.AddColumn(new DelegateColumn(delegate(MyObj obj) { 
         return getter(obj)-newLastGetter(obj); 
        }));
      }
      // ...
    }
