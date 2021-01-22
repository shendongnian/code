    public static void ResetFields(Control.ControlCollection pageControls)
        {
            foreach (Control contl in pageControls) 
            {
                var strCntName = (contl.GetType()).Name;
                switch (strCntName)
                {
                    case "Button":
                        contl.Enabled = true;
                        break;
                    case "TextBox":
                        var txtSource = (TextBox)contl;
                        txtSource.Text = "";
                        break;
                    case "ListBox":
                        var lstSource = (ListBox)contl;
                        lstSource.SelectedIndex = -1;
                        lstSource.Enabled = true;
                        break;
                    case "ComboBox":
                        var cmbSource = (ComboBox)contl;
                        cmbSource.SelectedIndex = -1;
                        cmbSource.Enabled = true;
                        break;
                    case "DataGridView":
                        var dgvSource = (DataGridView)contl;    
                        dgvSource.Rows.Clear();
                        break;
                    case "CheckBox":
                        var chkSource = (CheckBox)contl;
                        chkSource.Checked = false;
                        chkSource.Enabled = true;
                        break;
                }
                ResetFields(contl.Controls);
            }
        }
