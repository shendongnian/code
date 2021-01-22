    private void button1_Click(object sender, EventArgs e)
        {           
            textBox1.Enabled=false;
           
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Excell File |*.xlsx;*,xlsx";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string extn = Path.GetExtension(ofd.FileName);
                    if (extn.Equals(".xls") || extn.Equals(".xlsx"))
                    {
                        filename = ofd.FileName;
                        
                        if (filename != "")
                        {
                            try
                            {
                                string excelfilename = Path.GetFileName(filename);                               
                            }
                            catch (Exception ew)
                            {
                                MessageBox.Show("Errror:" + ew.ToString());
                            }
                        }
                    }
                }
