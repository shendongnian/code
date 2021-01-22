        public Window1()
        {
            InitializeComponent();
            ObservableCollection<Piece> pieces = new ObservableCollection<Piece>();
            pieces.Add(
                new Piece {Row = 0, Column = 0, Fill = new SolidColorBrush(Colors.BlanchedAlmond)});
            pieces.Add(
                new Piece {Row = 7, Column = 7, Fill = new SolidColorBrush(Colors.RosyBrown)});
            pieces.Add(
                new Piece { Row = 3, Column = 4, Fill = new SolidColorBrush(Colors.BlueViolet) });
            pieces.Add(
                new Piece { Row = 5, Column = 4, Fill = new SolidColorBrush(Colors.Orange) });
            Board.DataContext = pieces;
        }
