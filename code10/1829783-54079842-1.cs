    public class SudokuViewModel : ViewModelBase
    {
        private readonly string[,] _values;
        public SudokuViewModel(int width)
        {
            _values = new string[width, width];
        }
        public string this[int i, int j]
        {
            get => _values[i, j];
            set => Set(ref _values[i, j], value);
        }
    }
