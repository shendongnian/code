	public interface IMouseArgs
	{
		Point Pos { get; }
		void Capture();
		void Release();
		bool Handled { get; set; }
		... lots of other stuff
	}
