        public void OpenFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = openFile.FileName; // Input path from a file
                Excel excel = new Excel(path, 1); // Path is not declared...
                MessageBox.Show(excel.ReadCell(0, 0));
            }
        }
