     DialogResult dlg = MessageBox.Show("Question User?",
                       "MessageBox Title",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question);
                if (dlg == DialogResult.No)
                {
                    //user changed mind. return
                    return;
                }
