    using System;
    using System.Windows.Forms;
    
    namespace PropertyGridSample
    {
    	public class Form1 : System.Windows.Forms.Form
    	{
    		Layers layers_test;
    
    		internal System.Windows.Forms.PropertyGrid PropertyGrid1;
    
    		private System.ComponentModel.Container components = null; //Required designer variable
    
            public Form1()
    		{
    			InitializeComponent();
    
    			layers_test = new Layers();
    			PropertyGrid1.SelectedObject = layers_test;
            }
    
            // Clean up any resources being used
            protected override void Dispose( bool disposing )
    		{
    			if (disposing) { if (components != null) { components.Dispose(); } }
    
    			base.Dispose( disposing );
    		}
    
    		#region Windows Form Designer generated code
    		/// <summary>
    		/// Required method for Designer support - do not modify
    		/// the contents of this method with the code editor.
    		/// </summary>
    		private void InitializeComponent()
    		{
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
                this.PropertyGrid1 = new System.Windows.Forms.PropertyGrid();
                this.SuspendLayout();
                // 
                // PropertyGrid1
                // 
                this.PropertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
                this.PropertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
                this.PropertyGrid1.Location = new System.Drawing.Point(0, -1);
                this.PropertyGrid1.Name = "PropertyGrid1";
                this.PropertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
                this.PropertyGrid1.Size = new System.Drawing.Size(408, 254);
                this.PropertyGrid1.TabIndex = 1;
                this.PropertyGrid1.ToolbarVisible = false;
                this.PropertyGrid1.SelectedGridItemChanged += new System.Windows.Forms.SelectedGridItemChangedEventHandler(this.PropertyGrid1_SelectedGridItemChanged);
                // 
                // Form1
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.ClientSize = new System.Drawing.Size(408, 254);
                this.Controls.Add(this.PropertyGrid1);
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.Name = "Form1";
                this.Text = "Customizing Collections in Property Grid Demo";
                this.ResumeLayout(false);
    
    		}
    		#endregion
    
    		[STAThread]
    		static void Main() 
    		{
    			Application.Run(new Form1());
    		}
    
            private void PropertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
            {
                PropertyGrid1.Refresh();
            }
        }
    }
