	public class AsynchronousCrossThreadDelegate
	{
		public delegate void someFunctionDelegate(); 
		private Control _ctrl;
		private someFunctionDelegate _callback;
		private AsynchronousCrossThreadDelegate( Control ctrl, someFunctionDelegate callback )
		{
			_ctrl = ctrl;
			_callback = callback;
		}
		private void invoke()
		{
			_ctrl.BeginInvoke( _callback );
		}
		public static someFunctionDelegate Create( Control ctrl, someFunctionDelegate callback )
		{
			return (new AsynchronousCrossThreadDelegate( ctrl, callback )).invoke;
		}
	}
