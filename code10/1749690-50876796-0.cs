    class MainViewModel : INotifyPropertyChanged
    {
        // Note: this is just a sample.
        // You might want to inject the instances via DI
        public IEnumerable<INotifyPropertyChanged> TabItems { get; } =
            new[] { new PricesViewModel(), new LicensesViewModel() };
    }
