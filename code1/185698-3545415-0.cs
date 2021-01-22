    using (SaveFileDialog dialog = new SaveFileDialog()) {
        dialog.Filter = "Text files|*.txt";
        bool valid = false;
        while (true) {
            if (dialog.ShowDialog() == DialogResult.OK) {
                if (!System.IO.Path.GetExtension(dialog.FileName).Equals(".txt", StringComparison.InvariantCultureIgnoreCase)) {
                    MessageBox.Show("You must select a .txt file");
                }
                else {
                    File.WriteAllText(dialog.FileName, txtEditor.Text);
                    break; 
                }          
            }
            else break;
        }
    }
