    Grid grid1 = new Grid();
    panel1.Controls.Add(grid1);
    //grid1.Size = panel1.ClientSize;    // overlay full area..or..
    grid1.Init(4, 3, new Size(99, 44));  // .. use the overload with size
    grid1.Invalidate();
