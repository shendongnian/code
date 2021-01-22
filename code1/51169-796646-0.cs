    sealed class NicenessComboBoxItem
    {
        public string Description { get { return ...; } }
        public HowNice Value { get; private set; }
        public NicenessComboBoxItem(HowNice howNice) { Value = howNice; }
    }
