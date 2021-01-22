    using System;
    using System.Collections;
    using System.Windows.Forms;
    
    namespace WindowsApplication6
    {
    	public class Bar
    	{
    		public Bar()
    		{
    		}
    	}
    
    	public class Foo
    	{
    		private Bar m_Bar = new Bar();
    		private DateTime m_DateTime = DateTime.Now;
    
    		public Foo()
    		{
    		}
    
    		public Bar Bar
    		{
    			get
    			{
    				return m_Bar;
    			}
    			set
    			{
    				m_Bar = value;
    			}
    		}
    
    		public DateTime DateTime
    		{
    			get
    			{
    				return m_DateTime;
    			}
    			set
    			{
    				m_DateTime = value;
    			}
    		}
    	}
    
    	public class TestBugControl : UserControl
    	{
    		public TestBugControl()
    		{
    			InitializeComponent();
    		}
    
    		public void InitializeData(IList types)
    		{
    			this.cBoxType.DataSource = types;
    		}
    
    		public void BindFoo(Foo foo)
    		{
    			this.cBoxType.DataBindings.Add("SelectedItem", foo, "Bar");
    			this.dtStart.DataBindings.Add("Value", foo, "DateTime");
    		}
    
    		/// <summary>
    		/// Required designer variable.
    		/// </summary>
    		private System.ComponentModel.IContainer components = null;
    
    		/// <summary>
    		/// Clean up any resources being used.
    		/// </summary>
    		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    		protected override void Dispose(bool disposing)
    		{
    			if (disposing && (components != null))
    			{
    				components.Dispose();
    			}
    			base.Dispose(disposing);
    		}
    
    		#region Component Designer generated code
    
    		/// <summary>
    		/// Required method for Designer support - do not modify
    		/// the contents of this method with the code editor.
    		/// </summary>
    		private void InitializeComponent()
    		{
    			this.checkBox1 = new System.Windows.Forms.CheckBox();
    			this.cBoxType = new System.Windows.Forms.ComboBox();
    			this.dtStart = new System.Windows.Forms.DateTimePicker();
    			this.SuspendLayout();
    			//
    			// checkBox1
    			//
    			this.checkBox1.AutoSize = true;
    			this.checkBox1.Location = new System.Drawing.Point(14, 5);
    			this.checkBox1.Name = "checkBox1";
    			this.checkBox1.Size = new System.Drawing.Size(97, 20);
    			this.checkBox1.TabIndex = 0;
    			this.checkBox1.Text = "checkBox1";
    			this.checkBox1.UseVisualStyleBackColor = true;
    			//
    			// cBoxType
    			//
    			this.cBoxType.FormattingEnabled = true;
    			this.cBoxType.Location = new System.Drawing.Point(117, 3);
    			this.cBoxType.Name = "cBoxType";
    			this.cBoxType.Size = new System.Drawing.Size(165, 24);
    			this.cBoxType.TabIndex = 1;
    			//
    			// dtStart
    			//
    			this.dtStart.Location = new System.Drawing.Point(117, 40);
    			this.dtStart.Name = "dtStart";
    			this.dtStart.Size = new System.Drawing.Size(165, 23);
    			this.dtStart.TabIndex = 2;
    			this.dtStart.Visible = false;
    			//
    			// TestBugControl
    			//
    			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
    			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    			this.Controls.Add(this.dtStart);
    			this.Controls.Add(this.cBoxType);
    			this.Controls.Add(this.checkBox1);
    			this.Font = new System.Drawing.Font("Verdana", 9.75F,
    			System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,
    			((byte)(0)));
    			this.Margin = new System.Windows.Forms.Padding(4);
    			this.Name = "TestBugControl";
    			this.Size = new System.Drawing.Size(285, 66);
    			this.ResumeLayout(false);
    			this.PerformLayout();
    
    		}
    
    		#endregion
    
    		private System.Windows.Forms.CheckBox checkBox1;
    		private System.Windows.Forms.ComboBox cBoxType;
    		private System.Windows.Forms.DateTimePicker dtStart;
    	}
    
    	public class Form1 : Form
    	{
    		public Form1()
    		{
    			InitializeComponent();
    			this.Load += new EventHandler(Form1_Load);
    		}
    
    		void Form1_Load(object sender, EventArgs e)
    		{
    			InitializeControl();
    		}
    
    		public void InitializeControl()
    		{
    			TestBugControl control = new TestBugControl();
    			IList list = new ArrayList();
    			for (int i = 0; i < 10; i++)
    			{
    				list.Add(new Bar());
    			}
    			control.InitializeData(list);
    			control.BindFoo(new Foo());
    			this.Controls.Add(control);
    		}
    
    		/// <summary>
    		/// Required designer variable.
    		/// </summary>
    		private System.ComponentModel.IContainer components = null;
    
    		/// <summary>
    		/// Clean up any resources being used.
    		/// </summary>
    		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    		protected override void Dispose(bool disposing)
    		{
    			if (disposing && (components != null))
    			{
    				components.Dispose();
    			}
    			base.Dispose(disposing);
    		}
    
    		#region Windows Form Designer generated code
    
    		/// <summary>
    		/// Required method for Designer support - do not modify
    		/// the contents of this method with the code editor.
    		/// </summary>
    		private void InitializeComponent()
    		{
    			this.components = new System.ComponentModel.Container();
    			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    			this.Text = "Form1";
    		}
    
    		#endregion
    	}
    
    	static class Program
    	{
    		/// <summary>
    		/// The main entry point for the application.
    		/// </summary>
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			Application.Run(new Form1());
    		}
    	}
    }
