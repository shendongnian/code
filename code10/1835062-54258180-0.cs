class ComboBoxLikeFilter : FilteringBehavior, IFilteringBehavior
  {
    public override IEnumerable<object> FindMatchingItems(string searchText, IList items, IEnumerable<object> escapedItems, string textSearchPath, TextSearchMode textSearchMode)
    {
      if (string.IsNullOrWhiteSpace(searchText))
      {
        return ((IEnumerable<object>)items);//.Where(x => !escapedItems.Contains(x));
      }
      return base.FindMatchingItems(searchText, items, new object[0], textSearchPath, textSearchMode) as IEnumerable<object>;
    }
  }
and connect this to your AutoCompleteBox:
<telerik:GridViewDataColumn.CellEditTemplate>
<DataTemplate>
<telerik:RadAutoCompleteBox SelectedItem="{Binding RecipeCondition, Mode=TwoWay}" ItemsSource="{Binding DataContext.ConditionWordList, RelativeSource={RelativeSource AncestorType=telerik:RadGridView}}" SelectionMode="Multiple" AutoCompleteMode="SuggestAppend" TextSearchMode="Contains">
<telerik:RadAutoCompleteBox.FilteringBehavior>
<behavior:ComboBoxLikeFilter/>
</telerik:RadAutoCompleteBox.FilteringBehavior>
</telerik:RadAutoCompleteBox>
</telerik:GridViewDataColumn.CellEditTemplate>
This allows you to select items multiple times and get an ObservableCollection<string>. That wouldn't look right after you're finished (obviously telerik just calls the 'ToString' method to show the list) so I made my own
class StringList : ObservableCollection<string>
  {
    public override string ToString()
    {
      if(this.Count == 0)
      {
        return string.Empty;
      }
      return string.Join(" ", this);
    }
  }
Hope this helps someone, because that just cost me about 2 days to figure out. 
