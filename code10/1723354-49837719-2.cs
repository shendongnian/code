    // A: Use async in the click handler
	public async void button1_Click(object sender, EventArgs e)
	{
		try 
		{
            // B: await the completion of the task you started
			await RunTask();
		} 
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
    // C: Return a Task
	public Task RunTask()
	{
        // Return the Task that you started
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
