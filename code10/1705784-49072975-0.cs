	public partial class ChessSquare : UserControl
	{
		public enum Piece
		{
			King,
			Queen,
			Rook,
			Bishop,
			Knight,
			Pawn,
			None
		}
		public readonly SolidColorBrush BasicWhite = new SolidColorBrush(new Color { R = 255, G = 255, B = 255, A = 255 });
		public readonly SolidColorBrush BasicBlack = new SolidColorBrush(new Color { R = 0, G = 0, B = 0, A = 255 });
		public Boolean IsWhite
		{
			get { return (Boolean)this.GetValue(IsWhiteProperty); }
			set
			{
				this.SetValue(IsWhiteProperty, value);
				this.Background = value ? BasicWhite : BasicBlack;
			}
		}
		public static readonly DependencyProperty IsWhiteProperty = DependencyProperty.Register(
		  nameof(IsWhite), typeof(Boolean), typeof(ChessSquare), new PropertyMetadata(false, new PropertyChangedCallback(OnIsWhitePropertyChanged)));
		public Piece PieceType
		{
			get { return (Piece)this.GetValue(PieceProperty); }
			set { this.SetValue(PieceProperty, value); }
		}
		public static readonly DependencyProperty PieceProperty = DependencyProperty.Register(
		  nameof(PieceType), typeof(Piece), typeof(ChessSquare), new PropertyMetadata(Piece.None, new PropertyChangedCallback(OnPieceTypePropertyChanged)));
		public ChessSquare(int row, int col)
        {
            InitializeComponent();
			IsWhite = (row + col) % 2 == 0;
		}
		private static void OnIsWhitePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var square = (ChessSquare)d;
			square.Background = (bool)e.NewValue ? square.BasicWhite : square.BasicBlack;
		}
		private static void OnPieceTypePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			// change the image, set it to null is the value is Piece.None
		}
	}
