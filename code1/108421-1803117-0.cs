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
    	public partial class DragDropTestForm : Form
    	{
    		// Negative offset to drop location, to adjust for position where a drag starts
    		// on a label.
    		private Point _labelOffset;
    
    		// Save the full type name for a label, since this is used to test for the control type.
    		private string labelTypeName = typeof(Label).FullName;
    
    		public DragDropTestForm()
    		{
    			InitializeComponent();
    		}
    
    		private void dragDropLabel_MouseDown(object sender, MouseEventArgs e)
    		{
    			if (e.Button == MouseButtons.Left)
    			{
    				_labelOffset = new Point(-e.X, -e.Y);
    			}
    		}
    
    		private void dragDropLabel_MouseMove(object sender, MouseEventArgs e)
    		{
    			const double minimumDragDistance = 4;
    			const double minimumDragDistanceSquared = minimumDragDistance * minimumDragDistance;
    			
    			if (e.Button == MouseButtons.Left)
    			{
    				// Minimum n pixel movement before drag starts.
    				if (((Math.Pow(_labelOffset.X - e.X, 2)) + Math.Pow(_labelOffset.Y - e.Y, 2)) >= minimumDragDistanceSquared)
    				{
    					dragDropLabel.DoDragDrop(dragDropLabel, DragDropEffects.Move);
    				}
    			}		
    		}
    
    		private void DragDropTestForm_DragOver(object sender, DragEventArgs e)
    		{
    			IDataObject data = e.Data;
    			
    			string[] formats = data.GetFormats();
    
    			if (formats[0] == labelTypeName)
    			{
    				e.Effect = DragDropEffects.Move;
    			}
    		}
    
    		private void DragDropTestForm_DragDrop(object sender, DragEventArgs e)
    		{
    			IDataObject data = e.Data;
    
    			string[] formats = data.GetFormats();
    
    			if (formats[0] == labelTypeName)
    			{
    				Label label = (Label) data.GetData(formats[0]);
    				if (label == dragDropLabel)
    				{
    					Point newLocation = new Point(e.X, e.Y);
    					newLocation.Offset(_labelOffset);
    					dragDropLabel.Location = this.PointToClient(newLocation);
    				}
    			}
    		}
    	}
    }
