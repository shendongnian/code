    private void ListBox1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
    {
      // Draw the background of the ListBox control for each item.
      e.DrawBackground();
      // Define the default color of the brush as black.
      Brush myBrush = Brushes.Black;
      // Determine the color of the brush to draw each item based 
      // on the index of the item to draw.
      switch (e.Index)
      {
          case 0:
              myBrush = Brushes.Red;
              break;
          case 1:
              myBrush = Brushes.Orange;
              break;
          case 2:
              myBrush = Brushes.Purple;
              break;
      }
      // Draw the current item text based on the current Font 
      // and the custom brush settings.
      e.Graphics.DrawString(ListBox1.Items[e.Index].ToString(), 
        e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
      // If the ListBox has focus, draw a focus rectangle around the selected item.
      e.DrawFocusRectangle();
     }
