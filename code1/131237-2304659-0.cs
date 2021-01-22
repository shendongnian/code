    private Point? lastSelected;
    private Dictionary<Point, string> renderedText = new Dictionary<Point, string>();
    
    private Point LastSelected
    {
    	get
    	{
    		return (Point)lastSelected;
    	}
    }
    private void Form1_Load(object sender, EventArgs e)
    {
    	this.MouseDown += Form1_MouseDown;
    	this.KeyDown += Form1_KeyDown;
    	this.Paint += Form1_Paint;
    }
    void Form1_Paint(object sender, PaintEventArgs e)
    {
    	foreach (KeyValuePair<Point, string> pair in renderedText)
   	{
    		e.Graphics.DrawString(pair.Value, new Font("Arial", 12), Brushes.Black, 
    pair.Key);
       	}
       }
    
       void Form1_KeyDown(object sender, KeyEventArgs e)
       {
       	if (lastSelected != null)
       	{
       		if (!renderedText.ContainsKey(LastSelected))
       		{
       			renderedText.Add(LastSelected, "");
       		}
       		renderedText[LastSelected] = renderedText[LastSelected] + e.KeyCode;
       		this.Invalidate();
        	}
        }
    
    void Form1_MouseDown(object sender, MouseEventArgs e)
    {
    	lastSelected = e.Location;
    }
