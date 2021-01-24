    public class ViewModel : INotifyPropertyChanged
    {
        public List<Entry> Entries
        {
            get => _entries;
            set
            {
                if (Equals(value, _entries)) return;
                _entries = value;
                OnPropertyChanged();
            }
        }
        public ViewModel()
        {
            // Just some demo data
            Entries = new List<Entry>
            {
                new Entry(),
                new Entry(),
                new Entry(),
                new Entry()
            };
            // Make sure to listen to changes. 
            // If you add/remove items, don't forgat to add/remove the event handlers too
            foreach (Entry entry in Entries)
            {
                entry.PropertyChanged += EntryOnPropertyChanged;
            }
        }
        private void EntryOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            // Only re-check if the IsChecked property changed
            if(args.PropertyName == nameof(Entry.IsChecked))
                RecheckAllSelected();
        }
        private void AllSelectedChanged()
        {
            // Has this change been caused by some other change?
            // return so we don't mess things up
            if (_allSelectedChanging) return;
            try
            {
                _allSelectedChanging = true;
                // this can of course be simplified
                if (AllSelected == true)
                {
                    foreach (Entry kommune in Entries)
                        kommune.IsChecked = true;
                }
                else if (AllSelected == false)
                {
                    foreach (Entry kommune in Entries)
                        kommune.IsChecked = false;
                }
            }
            finally
            {
                _allSelectedChanging = false;
            }
        }
        private void RecheckAllSelected()
        {
            // Has this change been caused by some other change?
            // return so we don't mess things up
            if (_allSelectedChanging) return;
            try
            {
                _allSelectedChanging = true;
                if (Entries.All(e => e.IsChecked))
                    AllSelected = true;
                else if (Entries.All(e => !e.IsChecked))
                    AllSelected = false;
                else
                    AllSelected = null;
            }
            finally
            {
                _allSelectedChanging = false;
            }
        }
        public bool? AllSelected
        {
            get => _allSelected;
            set
            {
                if (value == _allSelected) return;
                _allSelected = value;
                // Set all other CheckBoxes
                AllSelectedChanged();
                OnPropertyChanged();
            }
        }
        private bool _allSelectedChanging;
        private List<Entry> _entries;
        private bool? _allSelected;
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
