    var sb = new StringBuilder();
    foreach (var ctrl in this.Controls) {
       if (ctrl Is TextBoxBase) {
           if (string.IsNullOrWhiteSpace(ctrl.Text)) {
              sb.AppendLine(ctrl.Name.Substring(3) + " is mandatory.");
           }
       }
    }
    MessageBox.Show(sb.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
    return;
