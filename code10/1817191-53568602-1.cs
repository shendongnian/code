        private void  FillGridview()
        {
            if (combobox.SelectedIndex == 0)
            {
                 Datagrid2.Visible = false;
                 Datagrid1.Visible = true;
            }
            else if (combobox.SelectedIndex == 1)
            {
                 Datagrid2.Visible = true;
                 Datagrid1.Visible = false;              
            }
           
