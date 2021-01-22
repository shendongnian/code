    private OpenMode _openFor;
    public OpenMode OpenFor
    {
        get{return _openFor;}
        set{
            _openFor = value;
            SetOpenFor(value);
        }
    }
    
    private void SetOpenFor(OpenMode mode)
    {
     if (mode== OpenMode.Add)
     {
         btnAddGuest.Text = "Save";
         btnUpdatePreference.Visible = false;
         dgvGuestInfo.ClearSelection();
     }
     else if (mode == OpenMode.Update)
     {
         btnAddGuest.Text = "Update";
         btnUpdatePreference.Visible = true;
     }
    }
