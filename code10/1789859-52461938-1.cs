    public class ViewModel
    {
        public ViewModel()
        {
            var allColors = typeof(Colors).GetProperties();
            foreach(var colorInfo in allColors)
            {
                this.Colors.Add(new ColorViewModel(colorInfo.Name, (Color)colorInfo.GetValue(null)));
            }
        }
        public ObservableCollection<ColorViewModel> Colors { get; } = new ObservableCollection<ColorViewModel>();
    }
