      private void frmLibrary_FormClosing(object sender, FormClosingEventArgs e)
      {
          e.Cancel = false;
          if (checkLogOff == false)
          {
              MessageBox.Show("Please Log Off before closing the Application");
              e.Cancel = true; // <--
              this.ControlBox = false;
              return;
          }
          else
          {
              this.ControlBox = true;
              e.Cancel = false; // <--
          }
      }
