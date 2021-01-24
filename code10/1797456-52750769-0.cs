	public class Span2D<T> where T : struct
	{
		protected readonly Span<T> _span;
		protected readonly int _width;
		protected readonly int _height;
		public Span2D(int height, int width)
		{
			T[] array = new T[_height * _width];
			_span = array.AsSpan();
		}
		public T this[int row, int column]
		{
			get
			{
				return _span[row * _height + column];
			}
			set
			{
				_span[row * _height + column] = value;
			}
		}
	}
