    private void AdjustWidthComboBox(ComboBox comboBox)
    {
        int width = comboBox.DropDownWidth;
        using (Graphics g = comboBox.CreateGraphics())
        {
            Font font = comboBox.Font;
            int vertScrollBarWidth =
                (comboBox.Items.Count > comboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;
            foreach (object item in comboBox.Items)
            {
                string valueToMeasure = comboBox.GetItemText(item);
                int newWidth = (int)g.MeasureString(valueToMeasure, font).Width + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
        }
        comboBox.DropDownWidth = width;
    }
    private void cbSample_DropDown(object sender, EventArgs e)
    {
        AdjustWidthComboBox(sender as ComboBox);
    }
