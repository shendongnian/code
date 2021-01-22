    protected override void PerformDataBinding()
    {
        base.PerformDataBinding();
    
        if (!IsBoundUsingDataSourceID && this.DataSource == null) return;
    
        HierarchicalDataSourceView view = this.GetData(string.Empty);
        if (view != null)
        {
            IHierarchicalEnumerable root = view.Select();
        }
    }
