    void Main()
    {
    	Form f = new Form();
    	Button b = new Button();
    	b.Click += (sender, args) =>
    	{
    		RichTextBox richTextBox = new RichTextBox
    		{
    			Name = "rtbBlahBlah",
    			Location = new System.Drawing.Point(12, 169),
    			Width = 62,
    			Height = 76
    		};
    		f.Controls.Add(richTextBox);
    	};
    	
    	f.Controls.Add(b);
    	f.Show();
    }
