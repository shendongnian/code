    public string EmployeeName
    {
        get
        {
            if (FilteredCollection != null)
                FilteredCollection.Filter = x => (String.IsNullOrEmpty(employeeName) || ((Employee)x).EmployeeName.Contains(employeeName));
            return employeeName;
        }
        set
        {
            employeeName = value;
            OnPropertyChanged("EmployeeName");
            if (FilteredCollection != null)
                FilteredCollection.Filter = x => (String.IsNullOrEmpty(employeeName) || ((Employee)x).EmployeeName.Contains(employeeName));
    
    
            // The changes
            if (String.IsNullOrEmpty(value))
                ClearFilter();
        }
    }
    
    // The changes
    private void ClearFilter()
    {
        FilteredCollection.Refresh();
    }
