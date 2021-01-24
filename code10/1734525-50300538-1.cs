	public class TracingView : IView 
	{ 
		private readonly string _name; 
		public IView InnerView { get; private set; }
		public TracingView(IView innerView, string name) 
		{ 
			InnerView = innerView; 
			_name = name; 
		}
		public void Render(ViewContext viewContext, TextWriter writer) 
		{ 
			var stopwatch = Stopwatch.StartNew(); 
			Trace.WriteLine(string.Format("View {0} - rendering...", _name)); 
			InnerView.Render(viewContext, writer); 
			stopwatch.Stop(); 
			Trace.WriteLine(string.Format("View {0} - rendered: {1} ms", _name, stopwatch.ElapsedMilliseconds)); 
		} 
	}
