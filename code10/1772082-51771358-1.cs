    Try using the draw item event and brushes...
    Example below:
    
           private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
            {
                        Brush brush = null;
                        ComboBox combo = (ComboBox) sender;
                        e.DrawBackground();
    
                        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                        
                        e.Graphics.FillRectangle(Brushes.Blue, e.Bounds);  //blue background
                        e.Graphics.DrawString("your string here", combo.Font, Brushes.Red, e.Bounds.X, e.Bounds.Y); //red font
            
            }
