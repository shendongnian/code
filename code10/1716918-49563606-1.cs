    public class MainWIndowViewModel
    {
        public CollectionView BrushesView { get; set; }
        private ObservableCollection<SolidColorBrush> BrushesList { get; set; } =
            new ObservableCollection<SolidColorBrush>
            {
                Brushes.Yellow, Brushes.Pink, Brushes.Blue, Brushes.Green, Brushes.Red, Brushes.Purple
            };
        public MainWIndowViewModel()
        {
            BrushesView = (CollectionView)new CollectionViewSource { Source = BrushesList }.View;
        }
    }
