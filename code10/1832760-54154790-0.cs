    <ListView x:Name="AssignmentsListView" Margin="20" ItemSelected="OnItemSelect">
    public void OnItemSelect(sender s, SelectedItemChangedEventArgs a) 
    {
       // a.SelectedItem will be the selected Item, you need to cast it
       var item = (MyClass)a.SelectedItem;
       ...
    }
