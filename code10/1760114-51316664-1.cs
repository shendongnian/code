	var btn = new System.Windows.Forms.Button()
	{
	    Name = "Button Name",
	    Text = "Button Text",
	    Size = new Size(69, 69),
	    Location = new Point(420, 420)
	}.Attach(b => b.Click += (s, e) => Console.WriteLine("Clicked!"));
	
	btn.PerformClick();
