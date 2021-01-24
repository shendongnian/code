    private void OnDropDownClosed(object e)
    {
       SelectedPerson = ComboBoxList.FirstOrDefault(x => x.IsChecked);
       FilterType = FilterType.Descending;
       this.RaisePropertyChange(nameof(FilterType));
       this.RaisePropertyChange(nameof(ComboBoxList));
     }
