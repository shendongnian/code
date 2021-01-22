    public static void ClearControls(Control c)
    {
        foreach (Control Ctrl in c.Controls)
        {
            //Console.WriteLine(Ctrl.GetType().ToString());
            //MessageBox.Show ( (Ctrl.GetType().ToString())) ;
            switch (Ctrl.GetType().ToString())
   
            {
                case "System.Windows.Forms.CheckBox":
                    ((CheckBox)Ctrl).Checked = false;
                    break;
                case "System.Windows.Forms.TextBox":
                    ((TextBox)Ctrl).Text = "";
                    break;
                case "System.Windows.Forms.RichTextBox":
                    ((RichTextBox)Ctrl).Text = "";
                    break;
                case "System.Windows.Forms.ComboBox":
                    ((ComboBox)Ctrl).SelectedIndex = -1;
                    ((ComboBox)Ctrl).SelectedIndex = -1;
                    break;
                case "System.Windows.Forms.MaskedTextBox":
                    ((MaskedTextBox)Ctrl).Text = "";
                    break;
                case "Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit":
                    ((UltraMaskedEdit)Ctrl).Text = "";
                    break;
                case "Infragistics.Win.UltraWinEditors.UltraDateTimeEditor":
                    DateTime dt = DateTime.Now;
                    string shortDate = dt.ToShortDateString();
                    ((UltraDateTimeEditor)Ctrl).Text = shortDate;
                    break;
                case "System.Windows.Forms.RichTextBox":
                    ((RichTextBox)Ctrl).Text = "";
                    break;
                case " Infragistics.Win.UltraWinGrid.UltraCombo":
                    ((UltraCombo)Ctrl).Text = "";
                    break;
                case "Infragistics.Win.UltraWinEditors.UltraCurrencyEditor":
                    ((UltraCurrencyEditor)Ctrl).Value = 0.0m;
                    break;
                default:
                    if (Ctrl.Controls.Count > 0)
                        ClearControls(Ctrl);
                    break;
            }
        }
    }
