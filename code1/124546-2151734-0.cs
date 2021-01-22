      private static void OnMenuClose_Click(object sender, System.EventArgs e)
      {
         Form dlg = ((Control) sender).FindForm();
         //dlg.DialogResult = DialogResult.OK;
         dlg.Close();
      }
