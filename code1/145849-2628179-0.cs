new RunTask&lt;string, string>("varA", "varB").StartThread();
public class RunTask&lt;TA, TB>
{
	public TA VarA { get; private set; }
	public TB VarB { get; private set; }
	public RunTask(TA varA, TB varB)
	{
		VarA = varA;
		VarB = varB;
	}
	public void StartThread()
	{
		ThreadPool.QueueUserWorkItem(Worker, this);
	}
	public void Worker(object obj)
	{
		var state = obj as RunTask&lt;TA,TB>;
		Console.WriteLine(state.VarA + ", " + state.VarB);
	}
}
