    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    
    namespace myNameSpace.Forms.UserControls
    {
    	public class TableLayoutPanelNoFlicker : TableLayoutPanel
    	{
    		public TableLayoutPanelNoFlicker()
    		{
    			this.DoubleBuffered = true;
    		}
    	}
    }
