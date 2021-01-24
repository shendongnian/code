    private void MyDGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control.GetType() == typeof(DataGridViewComboBoxEditingControl))
        {
            ComboBox cb = e.Control as ComboBox;
            if (cb != null)
            {
                //add these 2
                cb.DrawMode = DrawMode.OwnerDrawFixed;
                cb.DropDownStyle = ComboBoxStyle.DropDownList;
                cb.DrawItem += new DrawItemEventHandler(cbxDesign_DrawItem);
            }
        }
    }
