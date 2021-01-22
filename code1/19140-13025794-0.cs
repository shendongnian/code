    using System;
    using System.Windows.Forms;
    
    namespace FormClearing
    {
        class Helper
        {
            public static void ClearFormControls(Form form)
            {
                foreach (Control control in form.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txtbox = (TextBox)control;
                        txtbox.Text = string.Empty;
                    }
                    else if(control is CheckBox)
                    {
                        CheckBox chkbox = (CheckBox)control;
                        chkbox.Checked = false;
                    }
                    else if (control is RadioButton)
                    {
                        RadioButton rdbtn = (RadioButton)control;
                        rdbtn.Checked = false;
                    }
                    else if (control is DateTimePicker)
                    {
                        DateTimePicker dtp = (DateTimePicker)control;
                        dtp.Value = DateTime.Now;
                    }
                }
            }
        }
    }
