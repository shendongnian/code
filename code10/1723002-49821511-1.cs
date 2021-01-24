    private object _selectedItem;
    public object SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            cast to your model
            YourModel val=(YourModel)value;
            //checked is the new proprety that you added to ur model
            val.Checked=true;
            dosmthwithvalue(val);
           //this to unselect the item in listview /remove color
            _selectedItem = null;
            OnPropertyChanged("SelectedItem");
        }
    }
