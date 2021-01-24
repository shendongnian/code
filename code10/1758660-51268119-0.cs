    public class MainWindow_VM : BindableBase
    {
        public MainWindow_VM()
        {
            ...
            ListCollectionView selectedProcessorsView = new ListCollectionView(reportProcessors);
            selectedProcessorsView.LiveFilteringProperties.Add(nameof(Processor.IsEnabled));
            selectedProcessorsView.IsLiveFiltering = true;
            selectedProcessorsView.Filter = processorFilter;
            _selectedProcessorsView = selectedProcessorsView;
        }
        ...
     }
