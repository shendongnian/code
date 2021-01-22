    [Conditional("DEBUG")] 
    private void AssertValidity() 
    { 
        Debug.Assert(kosherBaconList.SelectedIndex != -1, "Nothing selected in kosher bacon list"); 
        Debug.Assert(kosherBaconList.COunt > 0, "kosher bacon list is empty!"); 
    } 
