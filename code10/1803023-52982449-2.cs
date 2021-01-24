    public class CustomToolStripSeparator : ToolStripSeparator
    {
        public CustomToolStripSeparator()
        {
            Paint += CustomToolStripSeparator_Paint;
        }
    private void CustomToolStripSeparator_Paint(object sender, PaintEventArgs e)
    {
        // Get the separator's width and height.
            ToolStripSeparator toolStripSeparator = (ToolStripSeparator)sender;
            int width = toolStripSeparator.Width;
            int height = toolStripSeparator.Height;
            //Color foreColor = Color.Blue;
            Color backColor = Color.Yellow;
            // Fill the background.
            e.Graphics.FillRectangle(new SolidBrush(backColor), 0, 0, width, height);
            // Draw the line.
            //e.Graphics.DrawLine(new Pen(foreColor), 4, height / 2, width - 4, height / 2);
    }
    }
