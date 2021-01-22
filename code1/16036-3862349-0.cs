        public void LockControlValues(System.Windows.Forms.Control Container)
        {
            try
            {
                foreach (Control ctrl in Container.Controls)
                {
                    if (ctrl.GetType() == typeof(TextBox))
                        ((TextBox)ctrl).ReadOnly = true;
                    if (ctrl.GetType() == typeof(ComboBox))
                        ((ComboBox)ctrl).Enabled= false;
                    if (ctrl.GetType() == typeof(CheckBox))
                        ((CheckBox)ctrl).Enabled = false;
                    if (ctrl.GetType() == typeof(DateTimePicker))
                        ((DateTimePicker)ctrl).Enabled = false;
                    if (ctrl.Controls.Count > 0)
                        LockControlValues(ctrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
