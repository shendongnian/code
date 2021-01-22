	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	using LightInfocon.Data.LightBaseProvider;
	using System.Configuration;
	namespace SINJRectifier
	{
		public partial class MainForm : Form
		{
			public MainForm()
			{
				InitializeComponent();
			}
			protected override void OnLoad(EventArgs e)
			{
				UserInterface userInterfaceObj = new UserInterface();
                this.chklbBasesList.Items.AddRange(userInterfaceObj.ExtentsList(this.chklbBasesList));
				MainFormInstance.MainFormInstanceSet = this; //Here I get the instance
			}
			private void btnBegin_Click(object sender, EventArgs e)
			{
				Maestro.ConductSymphony();
				ErrorHandling.SetExcecutionIsAllow();
			}
		}
		static class MainFormInstance  //Here I get the instance
		{
			private static MainForm mainFormInstance;
			public static MainForm MainFormInstanceSet { set { mainFormInstance = value; } }
			public static MainForm MainFormInstanceGet { get { return mainFormInstance; } }
		}
	}
