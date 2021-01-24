            private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Program?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                        Application.Exit();
                    else
                        e.Cancel = true;    //stopping Form Close perocess.
                }
            }
