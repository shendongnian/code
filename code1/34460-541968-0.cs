     foreach (Control ctrl in Page.Controls) {
          if (ctrl is TextBox) {
              if (ctrl.Text.Length != 0) {
                  output.Text += myStrings[i] + "/" + ctrl.Text;
               }
          }
     }
