    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Data;
    using System.Text;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    using System.Threading;
    
    namespace ForceUserControl
    {
    	[Designer(typeof(ButtonBarDesigner))]
    	public partial class ButtonBar : UserControl
    	{
    		public ButtonBar()
    		{
    			InitializeComponent();
    		}
    
    		/// <summary>
    		/// Returns inner panel.
    		/// </summary>
    		/// <remarks>Should allow persistence.</remarks>
    		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    		public Panel FillPanel
    		{
    			get { return fillPanel; }
    		}
    
    	}
    
    	private class ButtonBarDesigner : ParentControlDesigner
    	{
    		public override void Initialize(IComponent component)
    		{
			base.Initialize(component);
    			Panel fillPanel = ((ButtonBar)component).FillPanel;
    			// The name should be the same as the public property used to return the inner panel control.
    			base.EnableDesignMode(fillPanel, "FillPanel");
    		}
    	}
    }
