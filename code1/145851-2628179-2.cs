public class ListForm : Form
{
	private static readonly object _listResultLock = new object();
	private readonly Action&lt;TaskResult> _listResultHandler;
	public ListForm()
	{
		Load += ListForm_Load;
		_listResultHandler = TaskResultHandler;
	}
	private void ListForm_Load(object sender, EventArgs e)
	{
		new RunTask(new Task("varA", "varB", TaskResultHandler)).StartThread();
	}
	public void TaskResultHandler(TaskResult result)
	{
		if (InvokeRequired)
		{
			Invoke(_listResultHandler, result);
			return;
		}
		lock (_listResultLock)
		{
			// Update List
		}
	}
}
public class Task
{
	public Action&lt;TaskResult> Changed { get; private set; }
	public string VarA { get; private set; }
	public string VarB { get; private set; }
	public Task(string varA, string varB, Action&lt;TaskResult> changed)
	{
		VarA = varA;
		VarB = varB;
		Changed = changed;
	}
}
public class TaskResult
{
	public string VarA { get; private set; }
	public string VarB { get; private set; }
	public TaskResult(string varA, string varB)
	{
		VarA = varA;
		VarB = varB;
	}
}
public class RunTask
{
	private readonly Task _task;
	public RunTask(Task task)
	{
		_task = task;
	}
	public void StartThread()
	{
		ThreadPool.QueueUserWorkItem(Worker, _task);
	}
	public void Worker(object obj)
	{
		var state = obj as Task;
		if (state == null) return;
		if (state.Changed == null) return;
		state.Changed(new TaskResult("this is " + state.VarA, "this is " + state.VarA));
	}
}
