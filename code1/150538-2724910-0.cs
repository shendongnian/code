    void Main()
    {
    	Application.Run(new Form1());
    }
    
    public partial class Form1 : Form
    {
    	ComboBox ComboBox1;
    	string[] ds = new string[]{"Foo", "Bar", "Baz"};
    	
    	public Form1 ()
    	{
    		InitializeComboBox();
    	}
    
    	private void InitializeComboBox()
    	{
    		ComboBox1 = new ComboBox();
    		
    		ComboBox1.DataSource = ds;
    		Controls.Add(ComboBox1);
    		
    		ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
    		ComboBox1.DrawItem += new DrawItemEventHandler(ComboBox1_DrawItem);
    	}
    	
    	private void ComboBox1_DrawItem(object sender, DrawItemEventArgs e)
    	{
    		e.DrawBackground();
    		e.Graphics.DrawString(ds[e.Index],ComboBox1.Font,Brushes.Black,e.Bounds);
    
    		if (e.State == DrawItemState.Selected)
    		{
    			//stores the "HighlightedIndex" in the control's tag field.  Change as you see fit.
    			ComboBox1.Tag = e.Index; 
    			//Console.WriteLine(e.Index);
    		}
    	}
    }
