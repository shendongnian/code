    public partial class Form1 : Form
    {
    	private Nested m_Nested;
    
    	public Form1()
    	{
    		InitializeComponent();
    
    		m_Nested = new Nested(this);
    		m_Nested.Test();
    	}
    
    	private class Nested
    	{
    		private Form1 m_Parent;
    
    		protected Form1 Parent
    		{
    			get
    			{
    				return m_Parent;
    			}
    		}
    
    		public Nested(Form1 parent)
    		{
    			m_Parent = parent;
    		}
    
    		public void Test()
    		{
    			this.Parent.textBox1.Text = "Testing access to parent Form's control";
    		}
    	}
    }
