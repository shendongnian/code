    Color back = Color.Black;
    if (listBox2.SelectedIndex >= 0)
       back = (Color)listBox2.SelectedItem;
    
    using (Brush fill = new SolidBrush(back))
    using (Font text = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Regular))
    {
        e.Graphics.FillEllipse(fill, new Rectangle(1, 1+e.Index * 15, 100, 10));    
        e.Graphics.DrawEllipse(Pens.Blue, new Rectangle(1, 1 + e.Index * 15, 100, 10));  
        e.Graphics.DrawString(l.Items[e.Index].ToString(), text, Brushes.Red, e.Bounds);
    }
