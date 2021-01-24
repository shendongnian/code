    using System.IO;
    private void button1_Click(object sender, EventArgs e)
    {
        int DGVOriginalHeight = dataGridView1.Height;
        dataGridView1.Height = (dataGridView1.RowCount * dataGridView1.RowTemplate.Height) + 
                                dataGridView1.ColumnHeadersHeight;
        using (Bitmap bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height))
        {
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(Point.Empty, this.dataGridView1.Size));
            string DesktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            bitmap.Save(Path.Combine(DesktopFolder, "datagridview1.png"), ImageFormat.Png);
        }
        dataGridView1.Height = DGVOriginalHeight;
    }
