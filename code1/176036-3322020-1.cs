    public class Form1 : System.Windows.Forms.Form
    {
        System.Windows.Forms.ListBox ListBox1 = new System.Windows.Forms.ListBox();
        public Form1() : base()
        {
            this.Load += new System.EventHandler(Form1_Load);
            ListBox1.DrawItem+=new System.Windows.Forms.DrawItemEventHandler(ListBox1_DrawItem);
            ListBox1.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(ListBox1_MeasureItem);
        }
        private void ListBox1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;
            int i = System.Convert.ToInt32(ListBox1.Items[e.Index]);
            e.DrawBackground();
            if (i % 4 != 0)
            {
                string spaces = new string(' ', 20);
                e.Graphics.DrawString(
                    "Item #: " + i.ToString() + spaces.Replace(" ", " <Filler>"),
                        ListBox1.Font,
                        System.Drawing.Brushes.Black,
                        0,
                        e.Bounds.Top);
            }
            else
            {
                e.Graphics.DrawLine(
                    System.Drawing.Pens.Blue,
                    10,
                    e.Bounds.Top + 1,
                    52,
                    e.Bounds.Top + 1);
            }
            e.DrawFocusRectangle();
        }
        private void ListBox1_MeasureItem(object sender, System.Windows.Forms.MeasureItemEventArgs e)
        {
            if (e.Index == -1)
                return;
            if ((System.Convert.ToInt32(ListBox1.Items[e.Index]) % 4) == 0)
            {
                e.ItemHeight = 2;
            }
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            ListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            ListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            ClientSize = new System.Drawing.Size(454, 899);
            Controls.Add(ListBox1);
            for (int i = 0; i < 500; i++)
			{
                ListBox1.Items.Add(i);
			}
            ListBox1.Visible = true;
        }
    }
