    public class ListPresentationViewModel : ViewModelBase
    {
        private int _currCombinedIndex = 0;
        public List<WmtQ> Qs { get; set; }
        /// <summary>
        /// The <see cref="SelectedQ" /> property's name.
        /// </summary>
        public const string SelectedQPropertyName = "SelectedQ";
        private WmtQ _selectedQ = null;
        /// <summary>
        /// Sets and gets the SelectedQ property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public WmtQ SelectedQ
        {
            get
            {
                return _selectedQ;
            }
            set
            {
                Set(() => SelectedQ, ref _selectedQ, value);
            }
        }
        private RelayCommand _loadedCommand;
        /// <summary>
        /// Gets the LoadedCommand.
        /// </summary>
        public RelayCommand LoadedCommand
        {
            get
            {
                return _loadedCommand
                    ?? (_loadedCommand = new RelayCommand(
                    () =>
                    {
                        SelectedQ = Qs[_currCombinedIndex];
                    }));
            }
        }
        private RelayCommand _combinedAnimationCompletedCommand;
        /// <summary>
        /// Gets the CombinedAnimationCompletedCommand.
        /// </summary>
        public RelayCommand CombinedAnimationCompletedCommand
        {
            get
            {
                return _combinedAnimationCompletedCommand
                    ?? (_combinedAnimationCompletedCommand = new RelayCommand(
                    () =>
                    {
                        _currCombinedIndex++;
                        if (_currCombinedIndex < Qs.Count)
                        {
                            SelectedQ = Qs[_currCombinedIndex];
                        }
                    }));
            }
        }
        /// <summary>
        /// Initializes a new instance of the ListPresentationViewModel class.
        /// </summary>
        public ListPresentationViewModel()
        {
            Qs = new List<WmtQ>();
            var qList = new List<WmtQ> { new WmtQ("One", "A"), new WmtQ("Two", "B"), new WmtQ("Three", "C"), new WmtQ("Four", "D") };
            Qs = qList;
        }
    }
