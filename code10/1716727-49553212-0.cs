    Thread t = new Thread(() =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                DialogResult dr = openFileDialog.ShowDialog(new Form());
                if (dr == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    this.EditText0.Value = fileName;
                    SAPbouiCOM.Framework.Application.SBO_Application.MessageBox(fileName);
                }
            });          // Kick off a new thread
            t.IsBackground = true;
            t.SetApartmentState(ApartmentState.STA);
            t.Start();     
            
