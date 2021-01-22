    // The ListView's SelectedItem is bound to CurrentlySelectedItem
    var selectedItem = this.CurrentlySelectedItem;
    // ListView is bound to the Collection property
    // setting Collection automatically raises an INotifyPropertyChanged notification
    this.Collection = GetIssues(); // load collection with new data
    this.CurrentlySelectedItem = this.Collection.SingleOrDefault<Issue>(x => x.Id == selectedItem.Id);
