    Grid grid1 = new Grid();
    panel2.Controls.Add(grid1);
    //grid1.Size = panel2.ClientSize;    // overlay full area..or..
    grid1.Init(4, 3, new Size(99, 44));  // .. usethe overload with size
    grid1.Invalidate();
