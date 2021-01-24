	public class MyCustomControl : ContentControl 
	{ 
		private Canvas _canvas = new Canvas();
		public MyCustomControl()
		{
			this.Content = _canvas;
		}
	} 
