     // make a function named zpt 
     int rw=dataGridView1.Rows.Count;     //define rw as globly variable in form
     public void zpt()
        {
             PrintDialog pd = new PrintDialog();
             PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Arial", 10);
            PaperSize psz = new PaperSize("Custom", 100, 200);
            pd.Document = pdoc;
            pd.Document.DefaultPageSettings.PaperSize = psz;
            pdoc.DefaultPageSettings.PaperSize.Height = 820;
            pdoc.DefaultPageSettings.PaperSize.Width = 700;
            pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
            DialogResult res = pd.ShowDialog();
            if (res == DialogResult.OK)
            {
                PrintPreviewDialog prv = new PrintPreviewDialog();
                prv.Document = pdoc;
                res = prv.ShowDialog();
                if (res == DialogResult.OK)
                {
                    pdoc.Print();
                }
            }
        }
        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            float fontHeight = font.GetHeight();
            int startX = 50;
            int startY = 65;
            int Offset = 40;
            graphics.DrawString("Welcome to Bakery Shop", new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            string underLine = "------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            int a = dataGridView1.Rows.Count;
            for (int i = 0; i < a; i++)
            {
                graphics.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value), new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
                graphics.DrawString("\t"+Convert.ToString(dataGridView1.Rows[i].Cells[1].Value), new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
   
            dataGridView1.Rows.Add();
            dataGridView1.Rows[rw].Cells[0].Value = textBox1.Text;
            dataGridView1.Rows[rw].Cells[1].Value = textBox2.Text;
            rw++;
        }
        private void button2_Click(object sender, EventArgs e)
        {
           // on print Button which is in your window for code this...
            zpt();
        }
