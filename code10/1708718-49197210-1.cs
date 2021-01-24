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
            for (int i = 1; i <= 70; i++)
            {
                Rectangles.Add(new Rectangle(e.X - 50 - i * 5, e.Y - 40 - i * 5, 100, 80));
            }
    		Invalidate();
    	}
    }
