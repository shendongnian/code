    public partial class Form1 : Form
    {
    	bool dragging = false;
    	float Zoom = 1.0F;
    	Point lastMouse;
    	PointF viewPortCenter;
    
    	private readonly Brush solidYellowBrush = new SolidBrush(Color.Yellow);
    	private readonly Brush solidBlueBrush = new SolidBrush(Color.LightBlue);
    	const int matrix_x_size = 80;
    	const int matrix_y_size = 80;
    	private Bitmap[,] BmpMatrix = new Bitmap[matrix_x_size, matrix_y_size];
    	public Form1()
    	{
    		InitializeComponent();
    
    		Font font = new Font("Times New Roman", 10, FontStyle.Regular);
    		StringFormat strFormat = new StringFormat();
    		strFormat.Alignment = StringAlignment.Center;
    		strFormat.LineAlignment = StringAlignment.Center;
    		for (int y = 0; y < matrix_y_size; y++)
    			for (int x = 0; x < matrix_x_size; x++)
    			{
    				BmpMatrix[y, x] = new Bitmap(256, 256, PixelFormat.Format24bppRgb);
    				//                    BmpMatrix[y, x].Palette.Entries[0] = (x+y)%1==0?Color.Blue:Color.White;
    
    				using (Graphics g = Graphics.FromImage(BmpMatrix[y, x]))
    				{
    					g.FillRectangle(((x + y) % 2 == 0) ? solidBlueBrush : solidYellowBrush, new Rectangle(new Point(0, 0), new Size(256, 256)));
    					g.DrawString("hello world\n[" + x.ToString() + "," + y.ToString() + "]", new Font("Tahoma", 8), Brushes.Black,
    						new RectangleF(0, 0, 256, 256), strFormat);
    					g.DrawImage(BmpMatrix[y, x], Point.Empty);
    				}
    			}
    
    		BackColor = Color.White;
    
    		Size = new Size(300, 300);
    		Text = "Scroll Shapes Correct";
    
    		AutoScrollMinSize = new Size(256 * matrix_x_size, 256 * matrix_y_size);
    	}   
