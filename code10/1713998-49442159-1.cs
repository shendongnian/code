    private void Form1_Load(object sender, EventArgs e)
    {
    	List<TextBox> tbList = new List<TextBox>();
    	for (int i = 0; i < 3; i++)
    	{
    		TextBox tb = new TextBox();
    		tb.Text = "Test" + i.ToString();
    		tb.Name = "TextBox" + (i + 1).ToString();
    		tb.Location = new Point(0, 25 * i);
    		tb.Tag = i;
    		tbList.Add(tb);
    		this.Controls.Add(tb);
    	}
    	var tb2 = tbList.FirstOrDefault(tb => tb.Name == "TextBox2");
    	if (tb2 != null)
    		tb2.Text = "Modified text";
    
    	var sum = tbList.Sum(tb => (int)tb.Tag);
    }
