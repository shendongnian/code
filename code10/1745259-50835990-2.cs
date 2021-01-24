    public class DrawingContext : INotifyPropertyChanged {
        public DrawingContext() {
            BackColor = Color.White;
            Shapes = new BindingList<Shape>();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string name = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private Color backColor;
        public Color BackColor {
            get { return backColor; }
            set {
                if (!backColor.Equals(value)) {
                    backColor = value;
                    OnPropertyChanged();
                }
            }
        }
        private BindingList<Shape> shapes;
        public BindingList<Shape> Shapes {
            get { return shapes; }
            set {
                if (shapes != null)
                    shapes.ListChanged -= Shapes_ListChanged;
                shapes = value;
                OnPropertyChanged();
                shapes.ListChanged += Shapes_ListChanged;
            }
        }
        private void Shapes_ListChanged(object sender, ListChangedEventArgs e) {
            OnPropertyChanged("Shapes");
        }
        public DrawingContext Clone() {
            return new DrawingContext() {
                BackColor = this.BackColor,
                Shapes = new BindingList<Shape>(this.Shapes.Select(x => x.Clone()).ToList())
            };
        }
    }
