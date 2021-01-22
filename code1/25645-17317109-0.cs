            dlg =  new OpenFileDialog();
            dlg.Filter = "Doc File (*.doc,*.docx)|*.pdf*;*.xls,*.xlsx,*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
               txtFilename.Text = dlg.FileName;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = txtFilename.Text;
            string sFileName = "";
            long nLength = 0;
            byte[] barFile = null;
            if (dlg.FileName != "")
            {
                System.IO.FileStream fs = new System.IO.FileStream(dlg.FileName, System.IO.FileMode.Open);
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(dlg.FileName);
                sFileName = fileInfo.Name;
                nLength = fs.Length;
                barFile = new byte[fs.Length];
                fs.Read(barFile, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                PrintDialog pDialog = new PrintDialog();
                pDialog.Document = printDocument;
                if (pDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.DocumentName = dlg.FileName;
                    printDocument.Print();
                }
            }
            else
            {
                MessageBox.Show("Please Select the File For File Upload");
            }
        } 
