        private void ClearControls(Control.ControlCollection c)
        {
            foreach (Control control in c)
            {
                if (control.HasChildren)
                {
                    ClearControls(control.Controls);
                }
                else
                {
                    if (control is TextBox)
                    {
                        TextBox txt = (TextBox)control;
                        txt.Clear();
                    }
                    if (control is ComboBox)
                    {
                        ComboBox cmb = (ComboBox)control;
                        if (cmb.Items.Count > 0)
                            cmb.SelectedIndex = -1;
                    }
                    if (control is CheckBox)
                    {
                        CheckBox chk = (CheckBox)control;
                        chk.Checked = false;
                    }
                    if (control is RadioButton)
                    {
                        RadioButton rdo = (RadioButton)control;
                        rdo.Checked = false;
                    }
                    if (control is ListBox)
                    {
                        ListBox listBox = (ListBox)control;
                        listBox.ClearSelected();
                    }
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls((ControlCollection)this.Controls);
        }
