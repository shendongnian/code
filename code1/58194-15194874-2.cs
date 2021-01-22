     protected override void OnFormClosing(FormClosingEventArgs e)
              {
              base.OnFormClosing(e);
              if (e.CloseReason == CloseReason.WindowsShutDown) return;
                   switch (MessageBox.Show(this, "Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo))
                         {
                           case DialogResult.No:
                               e.Cancel = true;
                               break;
                         default:
                              break;
                         }
             }
