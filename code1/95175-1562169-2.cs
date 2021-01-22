<PRE>// the "main" or transparent window. Notice it just sets and runs the timer
using System;
using System.Windows.Forms;
namespace TransparencyPlusNottransparentTest
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			Program.ShowNontransparency();
		}
	}
}
// the "top" or not transparent window. Notice it does owner draw on
// transparent background. The design-time settings are also sans border etc.
using System.Drawing;
using System.Windows.Forms;
namespace TransparencyPlusNottransparentTest
{
	public partial class FormTop : Form
	{
		public FormTop()
		{
			InitializeComponent();
			BackColor = Color.Firebrick;
			TransparencyKey = Color.Firebrick;
		}
		private void FormTop_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawString("Hello Whirrled!", new Font("Tahoma", 14f), Brushes.Black, 10f, 10f );
		}
	}
}
// The control of this whole spiel. It instantiates both windows,
// sets the main as the main app window and hosts the public
// hacky method to force the non-transparent window to show up on top
// and offset so it doesn't obscure the top of the main window.
using System;
using System.Drawing;
using System.Windows.Forms;
namespace TransparencyPlusNottransparentTest
{
	static class Program
	{
		private static FormMain _formMain;
		private static FormTop _formTop;
		private const int XY_OFFSET = 30;
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			_formTop = new FormTop();
			_formTop.Show(null);
			_formMain = new FormMain();
			Application.Run(_formMain);
		}
		public static void ShowNontransparency()
		{
			_formTop.Location = 
				new Point(
				_formMain.Location.X + XY_OFFSET, 
				_formMain.Location.Y + XY_OFFSET);
			_formTop.BringToFront();
		}
	}
}</PRE>
