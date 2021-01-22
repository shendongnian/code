    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Data;
    using System.Runtime.InteropServices;
    namespace WindowsApplication
    {
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		[StructLayout(LayoutKind.Sequential)] 
			public struct DEV_BROADCAST_VOLUME 
		{ 
			public int dbcv_size; 
			public int dbcv_devicetype; 
			public int dbcv_reserved; 
			public int dbcv_unitmask; 
		} 
		protected override void WndProc(ref Message m) 
		{ 
			//you may find these definitions in dbt.h and winuser.h 
			const int WM_DEVICECHANGE = 0x0219; 
			const int DBT_DEVICEARRIVAL = 0x8000;  // system detected a new device 
			const int DBT_DEVICEREMOVECOMPLETE = 0x8001;  // system detected a new device 
			const int DBT_DEVTYP_VOLUME = 0x00000002;  // logical volume 
			switch(m.Msg)
			{
				case WM_DEVICECHANGE:
				switch(m.WParam.ToInt32())
				{
					case DBT_DEVICEARRIVAL:
						{ 
							int devType = Marshal.ReadInt32(m.LParam,4); 
							if(devType == DBT_DEVTYP_VOLUME) 
							{ 
								DEV_BROADCAST_VOLUME vol; 
								vol = (DEV_BROADCAST_VOLUME) 
									Marshal.PtrToStructure(m.LParam,typeof(DEV_BROADCAST_VOLUME)); 
								MessageBox.Show(vol.dbcv_unitmask.ToString("x")); 
							} 
						} 
						break;
					case DBT_DEVICEREMOVECOMPLETE:
						MessageBox.Show("Removal");
						break;
				}
					break;
			}
			//we detect the media arrival event 
			base.WndProc (ref m); 
		} 
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
		}
		#endregion
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}
	}
