    private void BindGrid()
    {
     this.radGridView1.GridElement.BeginUpdate();
     
     IQueryable queryable = new DataClasses1DataContext().MyTables.AsQueryable();
    
     if (!String.IsNullOrEmpty(where))
        {
            queryable = queryable.Where(where);
        }
    
     if (!String.IsNullOrEmpty(orderBy))
        {
            queryable = queryable.OrderBy(orderBy);
        }
    
        radGridView1.DataSource = queryable.Skip(currentPageIndex * pageSize).Take(pageSize);
    
     this.radGridView1.GridElement.EndUpdate(true);
    
        EnableDisablePager();
    }
