    public class ColorViewModel : INotifyPropertyChanged
    {
        public string _name;
        public Color _color;
        public ColorViewModel(string name, Color color)
        {
            this._name = name;
            this._color = color;
        }
        public string Name
        {
            get => this._name;
            set
            {
                if (value == this._name) return;
                this._name = value;
                this.OnPropertyChanged();
            }
        }
        public Color Color
        {
            get => this._color;
            set
            {
                if (value == this._color) return;
                this._color = value;
                this.OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
