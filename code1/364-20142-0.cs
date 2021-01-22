    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
    	public partial class Form1 : Form
    	{
    		private BindingSource source1 = new BindingSource();
    		private BindingSource source2 = new BindingSource();
    
    		public Form1()
    		{
    			InitializeComponent();
    			Load += new EventHandler(Form1Load);
    		}
    
    		void Form1Load(object sender, EventArgs e)
    		{
    			List<string> myitems = new List<string>
    {
    "Item 1",
    "Item 2",
    "Item 3"
    };
    
    			ComboBox box = new ComboBox();
    			box.Bounds = new Rectangle(10, 10, 100, 50);
    			source1.DataSource = myitems;
    			box.DataSource = source1;
    
    			ComboBox box2 = new ComboBox();
    			box2.Bounds = new Rectangle(10, 80, 100, 50);
    			source2.DataSource = myitems;
    			box2.DataSource = source2;
    
    			Controls.Add(box);
    			Controls.Add(box2);
    		}
    	}
    }
