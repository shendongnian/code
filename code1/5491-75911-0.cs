Like Philip Rieck said, the margin property is only respected by container controls that perform layout.  Here's an example that makes it fairly clear how the TableLayoutPanel respects the Margin property:
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TableLayoutPanel pnl = new TableLayoutPanel();
            pnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            pnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            pnl.Dock = DockStyle.Fill;
            this.Controls.Add(pnl);
            Button btn1 = new Button();
            btn1.Text = "No margin";
            btn1.Dock = DockStyle.Fill;
            Button btn2 = new Button();
            btn2.Margin = new Padding(25);
            btn2.Text = "Margin";
            btn2.Dock = DockStyle.Fill;
            pnl.Controls.Add(btn1, 0, 0);
            pnl.Controls.Add(btn2, 1, 0);
        }
    }
}
I believe the only .NET 2.0 built-in controls that respect this property are FlowLayoutPanel and TableLayoutPanel; hopefully third-party components respect it as well.  It has basically no effect in other scenarios.
