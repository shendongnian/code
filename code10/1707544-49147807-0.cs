    private void openAndAddToolStripMenuItem_Click(object sender, EventArgs e)
    {
        openFileDialog.Filter = "Text file|*.txt";
        openFileDialog.Title = "Open Text";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            var lines = File.ReadAllLines(openFileDialog.FileName);
            lines = lines.Where(line => !donutListBox.Items.Contains(line)).ToArray();
            donutListBox.Items.AddRange(lines);
        }
    } 
