    public class Size
    {
    	public Size(){}
    	
    	public Size(int width, int height)
    	{
    		this.Width = width;
    		this.Height = height;
    	}
    	
    	public int Width { get; set; }
    	
    	public int Height { get; set; }
    	
    	static public implicit operator System.Drawing.Size(Size convertMe)
    	{
    	   return new System.Drawing.Size(convertMe.Width, convertMe.Height);
    	}
    	
    	static public implicit operator Size(System.Drawing.Size convertMe)
    	{
    	   return new Size(convertMe.Width, convertMe.Height);
    	}
    }
    
    class Class1
    {
    	public Class1()
    	{
    		this.TheSize = new Size();
    	}
    	
    	public Size TheSize { get; set; }
    }
    
    public partial class Form1 : Form
    {
    	public Form1()
    	{
    		InitializeComponent();
    	}
    
    	private void Form1_Load(object sender, EventArgs e)
    	{
    		/// Style 1.
    		Class1 a = new Class1();
    		
    		a.TheSize = new Size(5, 10);
    		
    		/// Style 2.
    		Class1 c = new Class1();
    		
    		c.TheSize.Width = 400;
    		c.TheSize.Height = 800;
    		
    		/// The conversion from our Size to System.Drawing.Size
    		this.Size = c.TheSize;
    		
    		Class1 b = new Class1();
    		
    		/// The opposite conversion
    		b.TheSize = this.Size;
    		
    		Debug.Print("b Size: {0} x {1}", b.TheSize.Width, b.TheSize.Height);
    		
    		
    	}
    }
