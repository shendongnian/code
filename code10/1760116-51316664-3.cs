	void Main()
	{
		var btn = new Button()
		{
			Name = "Button Name",
			Text = "Button Text",
			Size = new Size(69, 69),
			Location = new Point(420, 420)
		}.Attach(b => b.Click += DesignerButton_OnClick);
	
		btn.PerformClick();
	}
	
	private static void DesignerButton_OnClick(object Sender, EventArgs Ev)
	{
		Console.WriteLine("Clicked!");
	}
