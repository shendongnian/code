csharp
using System.Collections.ObjectModel;
using DynamicData;
public class FilteringClass
{
   private readonly ReadOnlyObservableCollection<string> _filteredItems;
   private readonly SourceList<string> _items = new SourceList<string>();
   private string _filterTerm;
   public FilteringClass(IEnumerable<string> items)
   {
      _items.AddRange(items);
      _items.Connect()
         // This will update your output list whenever FilterTerm changes.
         .AutoRefresh(x => x.FilterTerm)
         // This is similar to a Where() statement.
         .Filter(x => FilterTerm == null || x.Contains(FilterTerm)
         // SourceList is thread safe, this will make your output list only be updated on the main thread.
         .ObserveOn(RxApp.MainThreadScheduler)
         // This will make the FilteredItem's be updated with our data.
         .Bind(out _filteredItems)
         // This is a observable, so Subscribe to start the goodness.
         .Subscribe();
   }
   public string FilterTerm
   {
      get => _filterTerm;
      set => RaiseAndSetIfChanged(ref _filterTerm, value);
   }
   public ReadOnlyObservableCollection<string> FilteredItems => _filteredItems;
}
