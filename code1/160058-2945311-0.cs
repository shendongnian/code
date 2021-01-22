    private void textBox1_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Copy;
    }
    private void textBox1_DragDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            var objPaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
            if (objPaths != null && objPaths.Length > 0 && File.Exists(objPaths[0]))
            {
                MessageBox.Show(string.Format("Filename: {0}", objPaths[0]));
                using (TextReader tr = new StreamReader(objPaths[0]))
                    textBox1.Text = tr.ReadToEnd();
            }
        }
    }
