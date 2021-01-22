    private void UpdateValue()
    {
       _selectedValue = Int32.Parse(GetSelectedValue());
    }
    
    private int _selectedValue;
    
    public int SelectedValue
    {
       get { return _selectedValue; }
    }
