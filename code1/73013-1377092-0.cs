    public static System.Windows.Forms.DialogResult WW_MessageBox(string Message, string Caption,
            System.Windows.Forms.MessageBoxButtons buttons, System.Windows.Forms.MessageBoxIcon icon,
            System.Windows.Forms.MessageBoxDefaultButton defaultButton)
        {
            System.Windows.Forms.MessageBox.Show(Message, Caption, buttons, icon, defaultButton,
                (System.Windows.Forms.MessageBoxOptions)8192 /*MB_TASKMODAL*/);
        }
