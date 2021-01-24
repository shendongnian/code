	void Main()
	{
		var form = new Form();
		var label = new Label(){Text = string.Format("{0:HH:mm:ss}", DateTime.UtcNow), AutoSize = true};
		form.Controls.Add(label);
		var taskController = new CancellationTokenSource(); 
		var token = taskController.Token;
		var task = Task.Run(() => 
		{
			for (var i=0; i<100; i++)
			{
				var text = string.Format("{0:HH:mm:ss}", DateTime.UtcNow);
				Console.WriteLine(text); //lets us see what the task does after the form's closed
				label.Text = text;
				if (token.IsCancellationRequested)
				{
					Console.WriteLine("Cancellation Token Detected");
					break;
				}
				Thread.Sleep(1000);
			}
		}, token);
		form.FormClosed += new FormClosedEventHandler((object sender, FormClosedEventArgs e) => {taskController.Cancel();});
		form.Show();
	}
	
