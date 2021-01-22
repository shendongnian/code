// This is the delegate to use to execute the process asynchronously
public delegate void ExecuteBackgroundDelegate();
//
[STAThread]
static void Main(string[] args)
{    			
	MyProcess proc = new MyProcess();
	// create an instance of our execution delegate
	ExecuteBackgroundDelegate asynchExec = new ExecuteBackgroundDelegate(proc.Execute);
			
	// execute this asynchronously
	asynchExec.BeginInvoke(null, null);
}
