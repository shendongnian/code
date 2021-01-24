    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        e.DrawBackground();
        Color TextColor = (workOrders[e.Index].Key == "S") ? Color.Red : Color.Blue;
        Color BackgroundColor = (workOrders[e.Index].Key == "S") ? Color.Olive : Color.Aquamarine;
        using (SolidBrush ForeColorBrush = new SolidBrush(TextColor))
        using (SolidBrush BackColorBrush = new SolidBrush(BackgroundColor))
        {
            e.Graphics.FillRectangle(BackColorBrush, e.Bounds);
            e.Graphics.DrawString(workOrders[e.Index].Value, listBox1.Font, ForeColorBrush, 
                                    e.Bounds, StringFormat.GenericTypographic);
        }
    }
    private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
    {
        e.ItemHeight = listBox1.Font.Height;
    }
