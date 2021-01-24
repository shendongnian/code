foreach (Control control in panelMain.Controls)
        {
            ComboBox comboBox = control as ComboBox;
            if(comboBox != null){
                try
                {
or
foreach (Control control in panelMain.Controls.Where(c => c is ComboBox))
