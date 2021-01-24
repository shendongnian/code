    // Draws a white rectangle with black border
    Rectangle rect = new Rectangle(0, 0, 100, 100);
    gr.FillRectangle(Brushes.Black, rect); // Draw border
    rect.Inflate(-1, -1); // Decrease the size of the rectangle by 1 pixel on all sides
    gr.FillRectangle(Brushes.White, rect); // Draw background above it
