            OpenFileDialog openfileDialog1 = new OpenFileDialog();
            if (openfileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.btnChoose2.Text = openfileDialog1.FileName;
                String filename = DialogResult.ToString();
                
                var excelApp = new Excel.Application();
                excelApp.Visible = true;
                excelApp.Workbooks.Open(btnChoose2.Text);
                
                
            }
