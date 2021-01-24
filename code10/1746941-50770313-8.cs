    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        e.DrawBackground();
        Color textColor = (workOrders[e.Index].Key == "S") ? Color.Red : Color.Blue;
        Color backColor = (workOrders[e.Index].Key == "S") ? Color.Olive : Color.Aquamarine;
        using (SolidBrush backColorBrush = new SolidBrush(backColor))
        using (SolidBrush foreColorBrush = new SolidBrush(textColor))
        {
            e.Graphics.FillRectangle(backColorBrush, e.Bounds);
            e.Graphics.DrawString(workOrders[e.Index].Value, listBox1.Font, foreColorBrush, 
                                  e.Bounds, StringFormat.GenericTypographic);
        }
    }
    private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
    {
        e.ItemHeight = listBox1.Font.Height;
    }
