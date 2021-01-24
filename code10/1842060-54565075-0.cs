    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    public partial class TLPTest1 : Form
    {
        public TLPTest1()
        {
            InitializeComponent();
            this.tlp1.RowStyles.RemoveAt(1);
        }
        private void TLPTest1_Load(object sender, EventArgs e)
        {
            PictureBox pBox = new PictureBox() {
                Anchor = AnchorStyles.None,
                BackColor = Color.Orange,
                MinimumSize = new Size(125, 125),
                Size = new Size(125, 125),
            };
            this.flp1.Controls.Add(pBox);
            this.tlp1.Controls.Add(flp1);
        }
        Random rnd = new Random();
        Size[] sizes = new Size[] { new Size(75, 75), new Size(100, 100), new Size(125, 125)};
        Color[] colors = new Color[] { Color.Red, Color.LightGreen, Color.YellowGreen, Color.SteelBlue };
        Control selectedObject = null;
        private void btnAddControl_Click(object sender, EventArgs e)
        {
            Size size = new Size(125, 125);
            if (this.chkRandom.Checked)
                size = sizes[rnd.Next(sizes.Length)];
            
            PictureBox pBox = new PictureBox() {
                Anchor = AnchorStyles.None,
                BackColor = colors[rnd.Next(colors.Length)],
                MinimumSize = size,
                Size = size
            };
            bool drawborder = false;
            pBox.MouseEnter += (s, evt) => { drawborder = true;  pBox.Invalidate(); };
            pBox.MouseLeave += (s, evt) => { drawborder = false; pBox.Invalidate(); };
            pBox.MouseDown += (s, evt) => { selectedObject = pBox;  pBox.Invalidate(); };
            pBox.Paint += (s, evt) => { if (drawborder) {
                    ControlPaint.DrawBorder(evt.Graphics, pBox.ClientRectangle, 
                                            Color.White, ButtonBorderStyle.Solid);
                }
            };
            var ctl = this.tlp1.GetControlFromPosition(0, this.tlp1.RowCount - 1);
            int overallWith = ctl.Controls.OfType<Control>().Sum(c => c.Width + c.Margin.Left + c.Margin.Right);
            overallWith += (ctl.Margin.Right + ctl.Margin.Left);
            if ((overallWith + pBox.Size.Width + pBox.Margin.Left + pBox.Margin.Right) >= this.tlp1.Width)
            {
                var flp = new FlowLayoutPanel() {
                    Anchor = AnchorStyles.Top | AnchorStyles.Bottom,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                };
                flp.Controls.Add(pBox);
                this.tlp1.SuspendLayout();
                this.tlp1.RowCount += 1;
                this.tlp1.Controls.Add(flp, 0, this.tlp1.RowCount - 1);
                this.tlp1.ResumeLayout(true);
            }
            else
            {
                ctl.Controls.Add(pBox);
            }
        }
        private void btnRemoveControl_Click(object sender, EventArgs e)
        {
            Control parent = selectedObject.Parent;
            selectedObject.Dispose();
            if (parent.Controls.Count == 0)
            {
                TLPRemoveRow(this.tlp1, parent);
                parent.Dispose();
            }
        }
        private void TLPRemoveRow(TableLayoutPanel tlp, Control control)
        {
            int ctlPosition = this.tlp1.GetRow(control);
            if (ctlPosition < this.tlp1.RowCount - 1)
            {
                for (int i = ctlPosition; i < this.tlp1.RowCount - 1; i++)
                {
                    tlp.SetRow(tlp.GetControlFromPosition(0, i + 1), i);
                }
            }
            tlp.RowCount -= 1;
        }
    }
