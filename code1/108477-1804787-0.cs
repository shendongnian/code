    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace DragDropTest
    {
    	public partial class LostFocusTestForm : Form
    	{
    		private Control _lastControl;
    
    		public LostFocusTestForm()
    		{
    			InitializeComponent();
    
    			TrapLostFocusOnChildControls(this.Controls);
    		}
    		private void finalTextBox_Enter(object sender, EventArgs e)
    		{
    			MessageBox.Show("From " + _lastControl.Name + " to " + this.ActiveControl.Name);
    		}
    		
    		private void AllLostFocus(object sender, EventArgs e)
    		{
    			_lastControl = (Control)sender;
    		}
    
    		private void TrapLostFocusOnChildControls(Control.ControlCollection controls)
    		{
    			foreach (Control control in controls)
    			{
    				control.LostFocus += new EventHandler(AllLostFocus);
    				
    				Control.ControlCollection childControls = control.Controls;
    				if (childControls != null)
    					TrapLostFocusOnChildControls(childControls);
    			}
    		}
    	}
    }
