    public class ScoutItems : ObservableCollection<ScoutItem>
    {
        public void Sort(SortDirection _sDir, string _sItem)
        {
                 //TODO: Add logic to look at _sItem and decide what property to sort on
                IEnumerable<ScoutItem> si_enum = this.AsEnumerable();
                if (_sDir == SortDirection.Ascending)
                {
                    si_enum = si_enum.OrderBy(p => p.UPC).AsEnumerable();
                } else
                {
                    si_enum = si_enum.OrderByDescending(p => p.UPC).AsEnumerable();
                }
                foreach (ScoutItem si in si_enum)
                {
                    int _OldIndex = this.IndexOf(si);
                    int _NewIndex = si_enum.ToList().IndexOf(si);
                    this.MoveItem(_OldIndex, _NewIndex);
                }
          }
    }
