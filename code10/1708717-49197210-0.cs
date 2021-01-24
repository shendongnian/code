    public partial class Form1 : Form
    {
    	private List<Rectangle> Rectangles { get; set; }
    
    	public Form1()
    	{
    		InitializeComponent();
    		Rectangles = new List<Rectangle>();
    	}
    
    	private void Form1_Paint(object sender, PaintEventArgs e)
    	{
    		if (Rectangles.Count > 0)
    			e.Graphics.DrawRectangles(Pens.Red, Rectangles.ToArray());
    	}
    
    	private void Form1_MouseClick(object sender, MouseEventArgs e)
    	{
    		Rectangles.Add(new Rectangle(e.Location, new Size(30, 20)));
    		Invalidate();
    	}
    }
