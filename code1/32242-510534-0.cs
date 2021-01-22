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
    		Class1 c = new Class1();
    		
    		c.TheSize.Width = 50;
    		c.TheSize.Height = 100;
    		
    		this.Size = c.TheSize;
    	}
    }
