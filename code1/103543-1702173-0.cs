    ...
    DataGridView dgvQueryResults;
    DataTable m_dataTable;
    BindingSource m_binder;
    public void PopulateView()
    {
      ...
      // Bind the data source through and intermediary BindingSource
      m_binder.DataSource = m_dataTable;
      dgvQueryResults.DataSource = m_binder;
      ...
    }
    
    
    /// <summary>
    /// Frees lindering resources. Sets data bindings to null and forces 
    /// garbage collection.
    /// </summary>
    private void ResetDataGridView()
    {
      dgvQueryResults.DataSource = null;
    
      if (null != m_binder) m_binder.DataSource = null;
      m_binder = null;
    
      dataTable = null;
    
      // Force garbage collection since this thing is a resource hog!
      GC.Collect ();
    
      m_binder = new BindingSource ();
    }
    
    ...
