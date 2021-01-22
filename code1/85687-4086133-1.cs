    public partial class MergeRowHeaderForm5 : Form
    {
        public MergeRowHeaderForm5()
        {
            InitializeComponent();
        }
        private void MergeRowHeaderForm5_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Columns.Add("JanWin", "Win");
            this.dataGridView1.Columns.Add("JanLoss", "Loss");
            this.dataGridView1.Columns.Add("FebWin", "Win");
            this.dataGridView1.Columns.Add("FebLoss", "Loss");
            this.dataGridView1.Columns.Add("MarWin", "Win");
            this.dataGridView1.Columns.Add("MarLoss", "Loss");
            this.dataGridView1.Columns.Add("AprWin", "Win");
            this.dataGridView1.Columns.Add("AprLoss", "Loss");
            this.dataGridView1.Columns.Add("MayWin", "Win");
            this.dataGridView1.Columns.Add("MayLoss", "Loss");
            for (int j = 0; j < this.dataGridView1.ColumnCount; j++)
            {
                this.dataGridView1.Columns[j].Width = 45;
            }
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridView1.ColumnHeadersHeight = this.dataGridView1.ColumnHeadersHeight * 2;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);
            this.dataGridView1.Paint += new PaintEventHandler(dataGridView1_Paint);
            this.dataGridView1.Scroll += new ScrollEventHandler(dataGridView1_Scroll);
            this.dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(dataGridView1_ColumnWidthChanged);
        }
        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = this.dataGridView1.DisplayRectangle;
            rtHeader.Height = this.dataGridView1.ColumnHeadersHeight / 2;
            this.dataGridView1.Invalidate(rtHeader);
        }
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = this.dataGridView1.DisplayRectangle;
            rtHeader.Height = this.dataGridView1.ColumnHeadersHeight / 2;
            this.dataGridView1.Invalidate(rtHeader);
        }
        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            string[] monthes = { "Emp Info", "", "", "", "" };
            for (int j = 0; j < 10; )
            {
                Rectangle r1 = this.dataGridView1.GetCellDisplayRectangle(j, -1, true);
                int w2 = this.dataGridView1.GetCellDisplayRectangle(j + 1, -1, true).Width;
                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w2 - 2;
                r1.Height = r1.Height / 2 - 2;
                e.Graphics.FillRectangle(new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(monthes[j / 2],
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Font,
                new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor),
                r1,
                format);
                j += 2;
            }
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }
        }
    }
