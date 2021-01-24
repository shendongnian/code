    private Point startLocation;
    private Point endLocation;
    private List<Rectangle> drawnItems = new List<Rectangle>();
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        // Capture the start point
        startLocation = new Point(e.X, e.Y);
    }
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        // Capture the end point
        endLocation = new Point(e.X, e.Y);
        // Save this rectangle in our list
        drawnItems.Add(new Rectangle(startLocation,
            new Size(endLocation.X - startLocation.X, endLocation.Y - startLocation.Y)));
        // Display a message
        var message = new StringBuilder();
        message.AppendLine("You drew a rectangle starting at point: " +
                        $"{startLocation} and ending at point: {endLocation}\n");
        message.AppendLine("Here are all the rectangles you've drawn:");
        for(int i = 0; i < drawnItems.Count; i++)
        {
            message.AppendLine($" {i + 1}. " + drawnItems[i]);
        }
        MessageBox.Show(message.ToString());
    }
