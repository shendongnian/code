    <TextBox x:Name="SO" TextChanged="" ... />
----------
    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        String orderNum = SO.Text;
        using (var stream = File.OpenRead(path))
        {
            order = (Bitmap)Bitmap.FromStream(stream);
        }
        using (order)
        using (var graphics = Graphics.FromImage(order))
        using (f)
        {
            graphics.DrawString(orderNum, f, System.Drawing.Brushes.White, order.Height / 2, order.Width / 2);
            order.Save(path);
        }
    }
