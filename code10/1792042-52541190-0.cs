    public RelayCommand<object> BoxChangeCommand { get { return new RelayCommand<object>(OnBoxChange); } }
    private void OnBoxChange(Object comboBox)
    {
        ComboBox list = comboBox as ComboBox;
        if (list != null) {
            //do stuff
            var items = list.Items;
            var selectedItem = list.SelectedItem;
        }
    }
