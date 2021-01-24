    private void button1_Click(object sender, EventArgs e)
    {
        //Resize DataGridView to full height.
        int DGVOriginalHeight = dataGridView1.Height;
        dataGridView1.Height = (dataGridView1.RowCount * dataGridView1.RowTemplate.Height) + dataGridView1.ColumnHeadersHeight;
        //Create a Bitmap and draw the DataGridView on it.
        using (Bitmap bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height))
        {
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(Point.Empty, this.dataGridView1.Size));
            string DesktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            bitmap.Save(Path.Combine(DesktopFolder, "datagridview1.png"), ImageFormat.Png);
        }
        //Resize DataGridView back to original height.
        dataGridView1.Height = DGVOriginalHeight;
