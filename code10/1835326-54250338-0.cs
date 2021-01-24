    private string _selectedColor;
    public string SelectedColor
    {
        get => _selectedColor;
        set
        {
            _selectedColor = value;
            ItemList.Clear();
            switch (_selectedColor)
            {
                case "red":
                   ItemList.Add("apple");
                   ItemList.Add("sun");
                   break;
            …
       }
       NotifyPropertyChanged(nameof(SelectedColor));
    }
