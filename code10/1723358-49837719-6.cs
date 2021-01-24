	// A: Use the async keyword, 
	// so we can use await in the method body
	public async void button1_Click(object sender, EventArgs e)
	{
		try
		{
			// B: await the completion of the task, 
			// without blocking the UI thread
			await RunTask();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
	// C: Change the signature to return a Task
	public Task RunTask()
	{
		// D: Return the task that you started
		return Task.Factory.StartNew(() =>
		{
			throw new Exception("SAMPLE_EXCEPTION");
		});
	}
	public event EventHandler<EventArgs> ButtonClickEvent;
	public static void Main()
	{
		var p = new Program();
		p.ButtonClickEvent += p.button1_Click;
		p.ButtonClickEvent(p, new EventArgs());
	}
