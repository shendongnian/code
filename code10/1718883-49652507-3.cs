    public class ItemViewModel : INotifyPropertyChanged
    {
        ...
        public string Name { get; set; } = "";
        public Color TextColor { get; set; } = Color.Black;
		// event handler for updating the list views
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged()
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
		}
    }
